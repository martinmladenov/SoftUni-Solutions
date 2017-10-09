namespace _07.Max_Seq_of_Incr_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int longestLength = 0;
            int lastInt = 0;
            int lastLength = 0;
            var longestSequence = new List<int>();
            for (var index = 0; index < arr.Length; index++)
            {
                var i = arr[index];
                if (lastInt < i)
                {
                    lastLength++;
                }
                else
                {
                    lastLength = 1;
                }
                lastInt = i;
                if (lastLength <= longestLength) continue;
                longestLength = lastLength;
                longestSequence.Clear();
                for (int j = index - lastLength + 1; j <= index; j++)
                {
                    longestSequence.Add(arr[j]);
                }
            }
            Console.WriteLine(string.Join(" ", longestSequence));
        }
    }
}
