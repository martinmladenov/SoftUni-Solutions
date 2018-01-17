namespace _05.Count_of_Occurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountOfOccurrences
    {
        public static void Main()
        {
            var occurrences = new SortedDictionary<int, int>();
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (var i in arr)
            {
                if (!occurrences.ContainsKey(i))
                {
                    occurrences[i] = 0;
                }

                occurrences[i]++;
            }

            foreach (var kvp in occurrences)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value} times");
            }
        }
    }
}
