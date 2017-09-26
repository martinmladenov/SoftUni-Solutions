using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            double h = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            if ((x > 0 && x < 3 * h && y > 0 && y < h) ||
                (y < 4 * h && y > 0 && x > h && x < 2 * h))
                Console.WriteLine("inside");
            else if (((x == 0 || x == 3 * h) && y >= 0 && y <= h) ||
                (y == 0 && x >= 0 && x <= 3 * h) ||
                (y == h && ((x >= 0 && x <= h) || (x >= 2 * h && x <= 3 * h))) ||
                (y == 4 * h && x >= h && x <= 2 * h) ||
                (y >= h && y <= 4 * h && (x == h || x == 2 * h)))
                Console.WriteLine("border");
            else Console.WriteLine("outside");

        }
    }
}