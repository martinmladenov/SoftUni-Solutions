using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<double> elements = new List<double>();

        for (int i = 0; i < n; i++)
        {
            elements.Add(double.Parse(Console.ReadLine()));
        }

        double toCompare = double.Parse(Console.ReadLine());

        Console.WriteLine(CountOfGreaterThan(elements, toCompare));
    }

    public static int CountOfGreaterThan<T>(List<T> list, T toCompare)
        where T : IComparable<T>
    {
        return list.Count(x => x.CompareTo(toCompare) > 0);
    }
}
