namespace _04.Longest_Incr_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var len = new int[nums.Length];
            var prev = new int[nums.Length];
            int last = -1;
            int maxLen = 0;
            for (int p = 0; p < nums.Length; p++)
            {
                prev[p] = -1;
                len[p] = 1;
                for (int left = 0; left < p; left++)
                {
                    if (nums[left] >= nums[p] || len[left] < len[p]) continue;
                    len[p] = 1 + len[left];
                    prev[p] = left;
                }
                if (len[p] <= maxLen) continue;
                maxLen = len[p];
                last = p;
            }
            var lis = new List<int>();
            for (int i = 0; i < maxLen; i++)
            {
                lis.Add(nums[last]);
                last = prev[last];
            }
            lis.Reverse();
            Console.WriteLine(string.Join(" ", lis));
        }
    }
}
