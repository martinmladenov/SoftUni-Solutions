namespace _11.Geometry_Calculator
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string figure = Console.ReadLine();
            double area;
            switch (figure)
            {
                case "triangle":
                    area = GetTriangleArea(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                    break;

                case "square":
                    area = GetSquareArea(double.Parse(Console.ReadLine()));
                    break;

                case "rectangle":
                    area = GetRectangleArea(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                    break;

                case "circle":
                    area = GetCircleArea(double.Parse(Console.ReadLine()));
                    break;

                default:
                    area = -1;
                    break;
            }
            Console.WriteLine($"{area:f2}");
        }

        public static double GetTriangleArea(double side, double height)
        {
            return side * height / 2;
        }

        public static double GetSquareArea(double side)
        {
            return Math.Pow(side, 2);
        }

        public static double GetRectangleArea(double width, double height)
        {
            return width * height;
        }

        public static double GetCircleArea(double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }
    }
}
