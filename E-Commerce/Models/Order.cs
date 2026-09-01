using E_Commerce.Enums;
using E_Commerce.Interfaces;

namespace E_Commerce.Models;

public class Order : IEntity
{
    private static int _idCounter;
    public int Id { get; }
    public CustomerRecord Customer { get; init; } = null!;
    public List<OrderItem> Items { get; set; } = null!;
    public OrderStatus Status { get; set; }
    public readonly DateTime OrderDate;
    public decimal TotalAmount => Items.Sum(x => x.Price * x.Quantity);
    public OrderItem this[int index]
    {
        get => Items[index];
        set => Items[index] = value;
    }
    public static explicit operator decimal(Order order) => order.TotalAmount;
    public static implicit operator string (Order order)
    {
        return $"Order ID: {order.Id}, Total Amount: {order.TotalAmount} AZN";
    }
}
