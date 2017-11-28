using Newtonsoft.Json;

public class OrderItem
{
    public OrderItem(int itemId, int quantity)
    {
        ItemId = itemId;
        Quantity = quantity;
    }

    [JsonProperty]
    public int ItemId { get; private set; }

    [JsonProperty]
    public int Quantity { get; private set; }
}
