namespace _04.Remove_Odd_Occurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveOddOccurrences
    {
        public static void Main()
        {
            var occurrences = new Dictionary<int, int>();
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (var i in arr)
            {
                if (!occurrences.ContainsKey(i))
                {
                    occurrences[i] = 0;
                }

                occurrences[i]++;
            }

            Console.WriteLine(string.Join(" ", arr.Where(i => occurrences[i] % 2 == 0)));
        }
    }
}
