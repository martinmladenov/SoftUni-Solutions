using System;

namespace _02.Circle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:f12}", r * r * Math.PI);
        }
    }
}
