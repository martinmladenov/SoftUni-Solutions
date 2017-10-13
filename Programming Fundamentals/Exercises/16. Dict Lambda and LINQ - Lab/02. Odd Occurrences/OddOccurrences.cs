namespace _02.Odd_Occurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class OddOccurrences
    {
        public static void Main()
        {
            var list = Console.ReadLine().Split().Select(s => s.ToLower());
            var counts = new Dictionary<string, int>();
            foreach (var s in list)
            {
                if (!counts.ContainsKey(s))
                    counts[s] = 1;
                else
                    counts[s]++;
            }
            Console.WriteLine(string.Join(", ", counts
                .Where(kvp => kvp.Value % 2 != 0)
                .Select(kvp => kvp.Key)));
        }
    }
}
