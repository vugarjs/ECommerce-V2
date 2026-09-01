namespace E_Commerce.Models;

public class OrderItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public OrderItem DeepCopy()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(this);

        OrderItem? item = System.Text.Json.JsonSerializer.Deserialize<OrderItem>(json);

        return item!;

    }
}
