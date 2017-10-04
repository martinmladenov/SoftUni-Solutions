using System;

namespace _04.Draw_a_Filled_Square
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintHeaderRow(n);
            for (int i = 0; i < n - 2; i++)
            {
                PrintMiddleRow(n);
            }

            PrintHeaderRow(n);
        }

        private static void PrintHeaderRow(int n)
        {
            Console.WriteLine(new string('-', n * 2));
        }

        private static void PrintMiddleRow(int n)
        {
            Console.Write('-');
            for (int i = 0; i < n - 1; i++)
            {
                Console.Write("\\/");
            }

            Console.WriteLine('-');
        }
    }
}