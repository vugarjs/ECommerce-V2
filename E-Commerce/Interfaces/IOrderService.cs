namespace E_Commerce.Interfaces;

public interface IOrderService<T>
{
    Task AddOrderAsync(T order);
    Task<T> GetOrderByIdAsync(int id);
    Task ProcessOrdersConcurrentlyAsync();
}
