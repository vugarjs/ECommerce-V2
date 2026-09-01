using E_Commerce.Interfaces;
using E_Commerce.Models;

namespace E_Commerce.Services;

internal class OrderProcessor<T> : IOrderService<T> where T : Order, IEntity
{
    List<T> values = new List<T>();
    private readonly object _lock = new();
    private readonly INotificationService _service;
    public Task AddOrderAsync(T order)
    {
        lock (_lock)
        {
            values.Add(order);
        }
        return Task.CompletedTask;
    }

    public Task<T> GetOrderByIdAsync(int id)
    {
      var Order = values.FirstOrDefault(o => o.Id == id);
        if (Order is not null)
        {
            return Task.FromResult(Order);
        }
        return Task.FromResult<T>(null);

    }

    public async Task ProcessOrdersConcurrentlyAsync()
    {
        await Parallel.ForEachAsync(values, async (order, cancellationToken) =>
        {
            await _service.NotifyAsync($"Processing order {order.Id}");
        });
    }   
    // ctor  injection for INotificationService
    public OrderProcessor(INotificationService service)
    {
       _service = service;
        values = new List<T>();
    }
}
