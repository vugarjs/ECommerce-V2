using System.Reflection;

namespace E_Commerce.Extensions;

public static class ReflectionHelper
{
    public static void InspectObject(object obj)
    {
        if (obj == null)
        {
            Console.WriteLine("Obyekt null-dır.");
            return;
        }
        var a = obj.GetType();
        Console.WriteLine($"--- Tip: {a.Name} ---");
        Console.WriteLine($"--- Obyekt: {obj} ---");

        var properties = a.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
        var fields = a.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        var methods = a.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        var constructors = a.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
        var attributes = a.GetCustomAttributes();

        foreach (var attribute in attributes)
        {
            Console.WriteLine($"--- Atribut: {attribute} ---");
        }
        foreach (var field in fields)
        {
            Console.WriteLine($"--- Sahə: {field.Name} ---");
            Console.WriteLine($"--- Dəyər: {field.GetValue(obj)} ---");
        }
        foreach(var method in methods)
        {
            Console.WriteLine($"--- Metod: {method.Name} ---");
        }
        foreach (var property in properties)
        {
            Console.WriteLine($"--- Xüsusiyyət: {property.Name} ---");
            Console.WriteLine($"--- Dəyər: {property.GetValue(obj)} ---");
        }
        foreach (var constructor in constructors)
        {
            Console.WriteLine($"--- Konstruktor: {constructor.Name} ---");
        }
    }
}
