using E_Commerce.Interfaces;

namespace E_Commerce.Services;

public class EmailNotificationService : INotificationService
{
    public Task NotifyAsync(string message);
}
