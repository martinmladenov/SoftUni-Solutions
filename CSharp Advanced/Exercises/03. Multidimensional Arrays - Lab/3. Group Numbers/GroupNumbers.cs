namespace _3.Group_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GroupNumbers
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int>[] groups = new List<int>[3];

            for (int i = 0; i < 3; i++)
            {
                groups[i] = new List<int>();
            }

            foreach (var i in nums)
            {
                groups[Math.Abs(i % 3)].Add(i);
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(string.Join(" ", groups[i]));
            }
        }
    }
}