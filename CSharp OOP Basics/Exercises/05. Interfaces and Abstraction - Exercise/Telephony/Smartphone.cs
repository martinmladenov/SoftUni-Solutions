using System;
using System.Linq;

public class Smartphone : ICaller, IInternetBrowser
{
    public void CallNumber(string number)
    {
        if (!number.All(char.IsNumber))
        {
            throw new ArgumentException("Invalid number!");
        }

        Console.WriteLine($"Calling... {number}");
    }

    public void BrowseWebsite(string website)
    {
        if (website.Any(char.IsNumber))
        {
            throw new ArgumentException("Invalid URL!");
        }

        Console.WriteLine($"Browsing: {website}!");
    }
}
