namespace Brackets.Domain.Extensions;

public static class StringExtension
{
    private static readonly Random random = new();

    public static string Tail(this string source, int tailLength)
    {
        return tailLength >= source.Length ?
            source :
            source[^tailLength..];
    }

    public static string Head(this string source, string token)
    {
        return source[..source.LastIndexOf(token, StringComparison.InvariantCulture)];
    }

    public static string Tail(this string source, string token)
    {
        return source[(source.IndexOf(token, StringComparison.InvariantCulture) + 1)..];
    }

    public static string FixPassword(this string source)
    {
        return source.Tail("!").Head("?");
    }

    public static string UnfixPassword(this string source)
    {
        return GetLetter() + "!" + source + "?" + GetNumbers();
    }

    public static char GetLetter()
    {
        // This method returns a random lowercase letter
        // ... Between 'a' and 'z' inclusize.
        int num = random.Next(0, 26); // Zero to 25
        char let = (char)('a' + num);
        return let;
    }

    public static int GetNumbers()
    {
        return random.Next(10, 99); // Zero to 25
    }
}
