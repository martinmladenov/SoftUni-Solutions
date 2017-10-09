namespace _03.Fold_and_Sum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = arr.Length / 4;
            var arrLeft = arr.Take(k).ToArray();
            var arrRight = arr.Skip(3 * k).ToArray();
            ReverseArray(arrLeft);
            ReverseArray(arrRight);
            var arrLower = arr.Skip(k).Take(2 * k).ToArray();
            var arrSum = new int[2 * k];
            arrLeft.CopyTo(arrSum, 0);
            arrRight.CopyTo(arrSum, k);
            SumArrays(arrSum, arrLower);
            Console.WriteLine(string.Join(" ", arrSum));
        }

        private static void SumArrays(int[] arr1, int[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
                arr1[i] += arr2[i];
        }

        private static void ReverseArray(int[] arr)
        {
            var original = arr.Clone() as int[];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = original[arr.Length - 1 - i];
            }
        }
    }
}
