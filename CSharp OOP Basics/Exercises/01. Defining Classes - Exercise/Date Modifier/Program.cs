using System;

// ReSharper disable CheckNamespace

public class Program
{
    public static void Main()
    {
        string date1 = Console.ReadLine();
        string date2 = Console.ReadLine();
        Console.WriteLine(DateModifier.CalculateDifference(date1, date2));
    }
}
