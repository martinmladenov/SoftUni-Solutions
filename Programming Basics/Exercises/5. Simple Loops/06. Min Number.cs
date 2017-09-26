using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int min = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                int a = int.Parse(Console.ReadLine());
                if (a < min)
                    min = a;

            }
            Console.WriteLine(min);

        }
    }
}