namespace _02.Odd_Filter
{
    using System;
    using System.Linq;

    public static class OddFilter
    {
        public static void Main()
        {
            var list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(i => i % 2 == 0)
                .ToList();
            var ave = list.Average();
            list = list.Select(i => i + (i > ave ? 1 : -1)).ToList();
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
