namespace _08.Most_Frequent_Number
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var repeats = new Dictionary<int, int>();
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            foreach (var i in arr)
            {
                if (repeats.ContainsKey(i))
                    repeats[i]++;
                else
                    repeats[i] = 1;
            }
            int maxNum = 0;
            int maxRepeats = 0;
            foreach (var kvp in repeats)
            {
                if (kvp.Value <= maxRepeats) continue;
                maxRepeats = kvp.Value;
                maxNum = kvp.Key;
            }
            Console.WriteLine(maxNum);
        }
    }
}
