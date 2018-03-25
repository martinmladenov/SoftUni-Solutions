using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<string> elements = new List<string>();

        for (int i = 0; i < n; i++)
        {
            elements.Add(Console.ReadLine());
        }

        string toCompare = Console.ReadLine();

        Console.WriteLine(CountOfGreaterThan(elements, toCompare));
    }

    public static int CountOfGreaterThan<T>(List<T> list, T toCompare)
        where T : IComparable<T>
    {
        return list.Count(x => x.CompareTo(toCompare) > 0);
    }
}
