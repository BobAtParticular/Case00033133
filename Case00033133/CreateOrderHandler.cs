using System.Linq;
using NServiceBus;
using NServiceBus.Logging;

public class CreateOrderHandler :
    IHandleMessages<CreateOrder>
{
    static ILog log = LogManager.GetLogger<CreateOrderHandler>();

    public void Handle(CreateOrder message)
    {
        log.Info($"Order received with {message.OrderItems.Count} subitems, the first being ItemId: {message.OrderItems.First().ItemId} / Quantity: {message.OrderItems.First().Quantity}");
    }
}
