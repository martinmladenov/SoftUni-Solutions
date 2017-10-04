using System;

namespace _06.Calculate_Triangle_Area
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = GetTriangleArea(width, height);
            Console.WriteLine(area);
        }

        private static double GetTriangleArea(double width, double height)
        {
            return width * height / 2;
        }
    }
}