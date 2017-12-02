using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using NServiceBus;
using StructureMap;

namespace Case00033133.Web
{
    public class Global : System.Web.HttpApplication
    {
        private IBus bus;

        protected void Application_Start(object sender, EventArgs e)
        {
            var container = new Container();

            var busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName("Case00033133");
            busConfiguration.UseSerialization<NewtonsoftJsonSerializer>();

            busConfiguration.UseContainer<StructureMapBuilder>(c => c.ExistingContainer(container));

            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.EnableInstallers();


            bus = Bus.Create(busConfiguration).Start();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            bus.Dispose();
        }
    }
}