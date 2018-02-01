namespace _7.Lego_Blocks
{
    using System;
    using System.Linq;

    public class LegoBlocks
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[][] arr = new int[n][];

            for (int i = 0; i < n; i++)
            {
                arr[i] = Console.ReadLine()
                    .Split(new[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int i = 0; i < n; i++)
            {
                arr[i] = arr[i].Concat(
                        Console.ReadLine()
                        .Split(new[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .Reverse())
                    .ToArray();
            }

            int length = arr[0].Length;
            bool fitting = true;
            int cells = arr[0].Length;

            for (int i = 1; i < n; i++)
            {
                if (fitting && length != arr[i].Length)
                {
                    fitting = false;
                }

                cells += arr[i].Length;
            }

            if (fitting)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"[{string.Join(", ", arr[i])}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {cells}");
            }

        }
    }
}
