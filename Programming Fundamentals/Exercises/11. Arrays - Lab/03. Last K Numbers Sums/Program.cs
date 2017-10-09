namespace _03.Last_K_Numbers_Sums
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            var arr = new long[n];
            arr[0] = 1;
            for (int i = 1; i < n; i++)
            {
                long sum = 0;
                for (int j = 1; j <= k && j <= i; j++)
                {
                    sum += arr[i - j];
                }
                arr[i] = sum;
            }
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
