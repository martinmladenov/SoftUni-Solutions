namespace _08._Custom_Comparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomComparator
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(arr, new MyComparator());
            Console.WriteLine(string.Join(" ", arr));
        }

        class MyComparator : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                int compare = Math.Abs(x % 2).CompareTo(Math.Abs(y % 2));
                if (compare == 0)
                {
                    compare = x.CompareTo(y);
                }

                return compare;
            }
        }
    }
}
