namespace E_Commerce.Extensions;

public static class StringExtensions
{
    public static string ToCapitalize(this string text)
    {
        if (string.IsNullOrEmpty(text))

            return text;

        if (text.Length == 1)
            return text.ToUpper();
        char a = char.ToUpper(text[0]);
        return a.ToString() + text.Substring(1).ToLower();
    }
}
