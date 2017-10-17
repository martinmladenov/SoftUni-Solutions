namespace _04.Distance_between_Points
{
    using System;
    using System.Linq;

    public class DistanceBetweenPoints
    {
        public static void Main()
        {
            var p1 = new Point(Console.ReadLine());
            var p2 = new Point(Console.ReadLine());
            Console.WriteLine("{0:f3}", CalcDistance(p1, p2));
        }

        private static double CalcDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }

    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(string s)
        {
            var split = s.Split().Select(int.Parse).ToArray();
            X = split[0];
            Y = split[1];
        }
    }
}
