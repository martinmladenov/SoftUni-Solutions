namespace _06.Rectangle_Position
{
    using System;
    using System.Linq;

    public class RectanglePosition
    {
        public static void Main()
        {
            var r1 = new Rectangle(Console.ReadLine());
            var r2 = new Rectangle(Console.ReadLine());
            Console.WriteLine(r1.IsInside(r2) ? "Inside" : "Not inside");
        }
    }

    public class Rectangle
    {
        public int Top { get; }
        public int Left { get; }
        public int Right { get; }
        public int Bottom { get; }

        public Rectangle(string input)
        {
            var split = input.Split().Select(int.Parse).ToArray();
            Left = split[0];
            Top = split[1];
            Right = Left + split[2];
            Bottom = Top + split[3];
        }

        public bool IsInside(Rectangle r)
        {
            return Left >= r.Left &&
                   Right <= r.Right &&
                   Top <= r.Top &&
                   Bottom <= r.Bottom;
        }
    }
}
