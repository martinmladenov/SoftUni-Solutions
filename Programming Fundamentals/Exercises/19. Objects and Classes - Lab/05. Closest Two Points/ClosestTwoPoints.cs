namespace _05.Closest_Two_Points
{
    using System;
    using System.Linq;

    public class ClosestTwoPoints
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var arr = new Point[n];
            for (int i = 0; i < n; i++)
                arr[i] = new Point(Console.ReadLine());
            int closestP1 = 0;
            int closestP2 = 0;
            double distance = 9999;
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                {
                    if (distance <= CalcDistance(arr[i], arr[j])) continue;
                    distance = CalcDistance(arr[i], arr[j]);
                    closestP1 = i;
                    closestP2 = j;
                }
            Console.WriteLine($"{distance:f3}");
            Console.WriteLine(arr[closestP1].GetCoordinates());
            Console.WriteLine(arr[closestP2].GetCoordinates());
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

        public string GetCoordinates()
        {
            return $"({X}, {Y})";
        }
    }
}
