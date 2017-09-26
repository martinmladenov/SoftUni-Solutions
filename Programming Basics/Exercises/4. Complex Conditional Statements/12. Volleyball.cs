using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            bool leap = Console.ReadLine() == "leap";
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            double played = 0;
            played += p * 2d / 3;
            played += (48d - h) * 3 / 4;
            played += h;
            if (leap) played*=1.15;
            Console.WriteLine(Math.Floor(played));

        }
    }
}