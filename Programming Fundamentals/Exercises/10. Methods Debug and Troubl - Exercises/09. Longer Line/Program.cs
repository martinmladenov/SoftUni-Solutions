namespace _09.Longer_Line
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double x1L1 = double.Parse(Console.ReadLine());
            double y1L1 = double.Parse(Console.ReadLine());
            double x2L1 = double.Parse(Console.ReadLine());
            double y2L1 = double.Parse(Console.ReadLine());
            double x1L2 = double.Parse(Console.ReadLine());
            double y1L2 = double.Parse(Console.ReadLine());
            double x2L2 = double.Parse(Console.ReadLine());
            double y2L2 = double.Parse(Console.ReadLine());
            PrintLongerLine(x1L1, y1L1, x2L1, y2L1, x1L2, y1L2, x2L2, y2L2);
        }

        public static void PrintLongerLine(double x1L1, double y1L1, double x2L1, double y2L1, double x1L2, double y1L2,
            double x2L2, double y2L2)
        {
            double line1Length = GetLineLength(x1L1, y1L1, x2L1, y2L1);
            double line2Length = GetLineLength(x1L2, y1L2, x2L2, y2L2);
            if (line1Length >= line2Length)
                PrintLineCoordinates(x1L1, y1L1, x2L1, y2L1);
            else
                PrintLineCoordinates(x1L2, y1L2, x2L2, y2L2);
        }

        public static void PrintLineCoordinates(double x1, double y1, double x2, double y2)
        {
            double distance1 = GetDistanceToCenter(x1, y1);
            double distance2 = GetDistanceToCenter(x2, y2);
            Console.WriteLine(distance1 <= distance2 ? $"({x1}, {y1})({x2}, {y2})" : $"({x2}, {y2})({x1}, {y1})");
        }

        public static double GetLineLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        public static double GetDistanceToCenter(double x, double y)
        {
            return GetLineLength(x, y, 0, 0);
        }
    }
}
