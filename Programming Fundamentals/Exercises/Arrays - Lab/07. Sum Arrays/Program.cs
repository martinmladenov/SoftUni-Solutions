namespace _07.Sum_Arrays
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr1 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var arr2 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int length = Math.Max(arr1.Length, arr2.Length);
            var arrSum = new int[length];
            for (int i = 0; i < length; i++)
            {
                arrSum[i] = arr1[i % arr1.Length] + arr2[i % arr2.Length];
            }
            Console.WriteLine(string.Join(" ", arrSum));
        }
    }
}
