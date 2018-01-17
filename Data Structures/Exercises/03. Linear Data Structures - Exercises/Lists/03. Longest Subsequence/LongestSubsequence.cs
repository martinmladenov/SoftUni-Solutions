namespace _03.Longest_Subsequence
{
    using System;
    using System.Linq;

    public class LongestSubsequence
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int mostNum = arr[0];
            int mostCount = 0;
            int lastNum = arr[0];
            int lastCount = 0;
            foreach (int num in arr)
            {
                if (lastNum != num)
                {
                    lastNum = num;
                    lastCount = 1;
                }
                else
                {
                    lastCount++;
                }

                if (mostCount >= lastCount) continue;
                mostCount = lastCount;
                mostNum = lastNum;
            }

            for (int i = 0; i < mostCount; i++)
            {
                Console.Write(mostNum + " ");
            }
        }
    }
}
