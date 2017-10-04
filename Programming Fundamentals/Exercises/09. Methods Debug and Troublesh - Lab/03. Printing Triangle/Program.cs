using System;

namespace _03.Printing_Triangle
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintTriangle(n);
        }

        private static void PrintTriangle(int end)
        {
            for (int i = 1; i <= end; i++)
                PrintLine(1, i);

            for (int i = end - 1; i >= 1; i--)
                PrintLine(1, i);
        }

        private static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
                Console.Write(i + " ");

            Console.WriteLine();
        }
    }
}