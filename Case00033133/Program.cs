﻿using System;
using System.Collections.Generic;
using NServiceBus;
using StructureMap;

static class Program
{
    static void Main()
    {
        Console.Title = "Case00033133";
        #region config

        var container = new Container();

        var busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("Case00033133");
        busConfiguration.UseSerialization<NewtonsoftJsonSerializer>();

        busConfiguration.UseContainer<StructureMapBuilder>(c => c.ExistingContainer(container));

        // register the mutator so the the message on the wire is written
        busConfiguration.RegisterComponents(components =>
        {
            components.ConfigureComponent<MessageBodyWriter>(DependencyLifecycle.InstancePerCall);
        });
        #endregion
        busConfiguration.UsePersistence<InMemoryPersistence>();
        busConfiguration.EnableInstallers();


        using (var bus = Bus.Create(busConfiguration).Start())
        {
            #region message
            var message = new CreateOrder
            {
                OrderId = 9,
                Date = DateTime.Now,
                CustomerId = 12,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem(6, 2),
                    new OrderItem(5, 4),
                }
            };
            bus.SendLocal(message);
            #endregion
            Console.WriteLine("Order Sent");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}