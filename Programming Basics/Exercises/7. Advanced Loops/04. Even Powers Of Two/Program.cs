using System;

namespace _04.Even_Powers_Of_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int t = 1;
            for (int i = 0; i <= n / 2; i++)
            {
                Console.WriteLine(t);
                t *= 4;
            }
        }
    }
}
