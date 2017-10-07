namespace _02.Reverse_Array_of_Integers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ", arr.Reverse()));
        }
    }
}
