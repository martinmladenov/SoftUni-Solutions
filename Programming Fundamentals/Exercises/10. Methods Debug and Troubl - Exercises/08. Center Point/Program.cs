namespace _08.Center_Point
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            PrintCloserPoint(x1, y1, x2, y2);
        }

        public static void PrintCloserPoint(double x1, double y1, double x2, double y2)
        {
            double distance1 = GetDistance(x1, y1);
            double distance2 = GetDistance(x2, y2);
            Console.WriteLine(distance1 < distance2 ? $"({x1}, {y1})" : $"({x2}, {y2})");
        }

        public static double GetDistance(double x, double y)
        {
            return Math.Abs(x) + Math.Abs(y);
        }
    }
}
