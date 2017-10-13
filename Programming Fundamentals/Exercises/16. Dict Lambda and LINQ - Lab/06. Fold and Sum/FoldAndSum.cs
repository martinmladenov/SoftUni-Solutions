namespace _06.Fold_and_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class FoldAndSum
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();
            int k = input.Count / 4;
            var upper = new List<int>();
            upper.AddRange(input.Take(k).Reverse());
            upper.AddRange(input.Skip(3 * k).Reverse());
            var lower = input.Skip(k).Take(2 * k).ToList();
            var sum = upper.Select((i, index) => i + lower[index]);
            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
