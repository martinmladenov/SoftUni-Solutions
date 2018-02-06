namespace _02._Sum_Numbers
{
    using System;
    using System.Linq;

    public class SumNumbers
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(arr.Length);
            Console.WriteLine(arr.Sum());
        }
    }
}
