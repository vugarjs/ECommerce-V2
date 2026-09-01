using System.Text.Json;

namespace E_Commerce.Data;

public static class DataManager
{
    static string path = "C:\\Users\\Vuqar\\Desktop\\v\\Tasks\\ECommerce-V2\\E-Commerce\\Files\\data.json";
    static DirectoryInfo DirectoryInfo = new(path);

    public static async Task SaveOrdersAsync<T>(List<T> orders)
    {
        var json = JsonSerializer.Serialize(orders);

        await File.WriteAllTextAsync(path, json);
    }
    public static async Task<List<T>> LoadOrdersAsync<T>()
    {
        var json = await File.ReadAllTextAsync(path);
        return JsonSerializer.Deserialize<List<T>>(json);
    }

}
