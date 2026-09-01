namespace E_Commerce.Interfaces;

public interface INotificationService
{
    Task NotifyAsync(string message);
}
