namespace _02.Rotate_and_Sum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());
            var sum = new int[arr.Length];
            for (int i = 0; i < k; i++)
            {
                RotateArray(arr);
                SumArrays(sum, arr);
            }
            Console.WriteLine(string.Join(" ", sum));
        }

        private static void SumArrays(int[] arr1, int[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
                arr1[i] += arr2[i];
        }

        private static void RotateArray(int[] arr)
        {
            var original = arr.Clone() as int[];
            arr[0] = original[arr.Length - 1];
            for (int i = 1; i < arr.Length; i++)
                arr[i] = original[i - 1];
        }
    }
}
