using System;



static class ExtensionFunction
{
    static string Three(this string value)
    {
        return value.Substring(0, 3);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("안녕하세요".Three());
    }
}

