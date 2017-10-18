namespace _03.Circles_Intersection
{
    using System;
    using System.Linq;

    public class CirclesIntersection
    {
        public static void Main()
        {
            var c1 = new Circle(Console.ReadLine());
            var c2 = new Circle(Console.ReadLine());
            Console.WriteLine(Intersect(c1, c2) ? "Yes" : "No");
        }

        private static bool Intersect(Circle c1, Circle c2)
        {
            double distance = Math.Sqrt(Math.Pow(c1.X - c2.X, 2) + Math.Pow(c1.Y - c2.Y, 2));
            return distance <= c1.Radius + c2.Radius;
        }
    }

    public class Circle
    {
        public int X { get; }
        public int Y { get; }
        public int Radius { get; }

        public Circle(string input)
        {
            var split = input.Split().Select(int.Parse).ToArray();
            X = split[0];
            Y = split[1];
            Radius = split[2];
        }
    }
}
