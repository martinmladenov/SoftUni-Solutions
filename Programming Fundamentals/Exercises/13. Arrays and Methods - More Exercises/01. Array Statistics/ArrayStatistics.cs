namespace _01.Array_Statistics
{
    using System;
    using System.Linq;

    public static class ArrayStatistics
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine($"Min = {arr.Min()}");
            Console.WriteLine($"Max = {arr.Max()}");
            Console.WriteLine($"Sum = {arr.Sum()}");
            Console.WriteLine($"Average = {arr.Average()}");
        }
    }
}
