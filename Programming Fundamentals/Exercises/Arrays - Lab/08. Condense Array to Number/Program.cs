namespace _08.Condense_Array_to_Number
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            while (arr.Length > 1)
            {
                var condensed = new int[arr.Length - 1];
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    condensed[i] = arr[i] + arr[i + 1];
                }
                arr = condensed;
            }
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
