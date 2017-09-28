using System;

namespace _03.Megapixels
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine(width + "x" + height + " => " + Math.Round((double)width * height / 1000000, 1) + "MP");
        }
    }
}
