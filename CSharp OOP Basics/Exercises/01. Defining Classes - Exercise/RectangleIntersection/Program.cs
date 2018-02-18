using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable CheckNamespace

public class Program
{
    public static void Main()
    {
        int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = parameters[0];
        int m = parameters[1];

        Dictionary<string, Rectangle> rectangles = new Dictionary<string, Rectangle>();

        for (int i = 0; i < n; i++)
        {
            string[] split = Console.ReadLine().Split();
            string id = split[0];
            double width = double.Parse(split[1]);
            double height = double.Parse(split[2]);
            double x = double.Parse(split[3]);
            double y = double.Parse(split[4]);

            rectangles[id] = new Rectangle(width, height, x, y);
        }

        for (int i = 0; i < m; i++)
        {
            string[] split = Console.ReadLine().Split();

            Rectangle rect1 = rectangles[split[0]];
            Rectangle rect2 = rectangles[split[1]];

            Console.WriteLine(rect1.Intersects(rect2) ? "true" : "false");
        }
    }
}
