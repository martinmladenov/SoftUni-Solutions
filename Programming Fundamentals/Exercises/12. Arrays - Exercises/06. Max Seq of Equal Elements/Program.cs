namespace _06.Max_Seq_of_Equal_Elements
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int longestInt = 0;
            int longestLength = 0;
            int lastInt = 0;
            int lastLength = 0;
            foreach (var i in arr)
            {
                if (lastInt == i)
                {
                    lastLength++;
                }
                else
                {
                    lastInt = i;
                    lastLength = 1;
                }
                if (lastLength <= longestLength) continue;
                longestLength = lastLength;
                longestInt = i;
            }

            for (int i = 0; i < longestLength; i++)
                Console.Write(longestInt + " ");
        }
    }
}
