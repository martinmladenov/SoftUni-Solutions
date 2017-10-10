namespace _07.Count_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var repetitions = new Dictionary<int, int>();
            foreach (var i in arr)
            {
                if (repetitions.ContainsKey(i))
                    repetitions[i]++;
                else
                    repetitions[i] = 1;
            }
            foreach (var kvp in repetitions.OrderBy(kvp => kvp.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
