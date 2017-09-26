using System;

namespace Square_Frame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.Write(i == 1 || i == n ? "+" : "|");
                for (int j = 0; j < n-2; j++)
                {
                    Console.Write(" -");
                }
                Console.WriteLine(i == 1 || i == n ? " +" : " |");
            }
        }
    }
}
