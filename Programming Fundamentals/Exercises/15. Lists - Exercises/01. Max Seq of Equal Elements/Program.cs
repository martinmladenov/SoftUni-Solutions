namespace _01.Max_Seq_of_Equal_Elements
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int bestNum = 0;
            int bestLength = 0;
            int lastNum = 0;
            int lastLength = 0;
            foreach (var i in list)
            {
                if (i == lastNum)
                {
                    lastLength++;
                }
                else
                {
                    lastLength = 1;
                    lastNum = i;
                }
                if (bestLength >= lastLength) continue;
                bestNum = lastNum;
                bestLength = lastLength;
            }
            for (int i = 0; i < bestLength; i++)
            {
                Console.Write(bestNum + " ");
            }
        }
    }
}
