namespace _10.Pairs_by_Difference
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int targetDifference = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
                for (int j = i; j < arr.Length; j++)
                    if (Math.Abs(arr[i] - arr[j]) == targetDifference)
                        count++;
            Console.WriteLine(count);
        }
    }
}
