namespace _01.Count_Real_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class CountRealNumbers
    {
        public static void Main()
        {
            var list = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();
            var counts = new SortedDictionary<double, int>();
            foreach (var d in list)
            {
                if (!counts.ContainsKey(d))
                    counts[d] = 1;
                else
                    counts[d]++;
            }
            foreach (var kvp in counts)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
