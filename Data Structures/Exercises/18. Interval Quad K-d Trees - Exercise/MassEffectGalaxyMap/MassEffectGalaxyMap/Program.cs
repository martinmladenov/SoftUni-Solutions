namespace MassEffectGalaxyMap
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            Rectangle allSpace = new Rectangle(0, 0, size, size);

            List<Point2D> clusters = new List<Point2D>();

            for (int i = 0; i < n; i++)
            {
                string[] clusterData = Console.ReadLine().Split();
                Point2D cluster = new Point2D(double.Parse(clusterData[1]), double.Parse(clusterData[2]));

                if (cluster.IsInside(allSpace))
                {
                    clusters.Add(cluster);
                }
            }

            KdTree kdTree = new KdTree();

            clusters.ForEach(kdTree.Insert);

            for (int i = 0; i < m; i++)
            {
                string[] rectData = Console.ReadLine().Split();
                double x1 = double.Parse(rectData[1]);
                double y1 = double.Parse(rectData[2]);
                double x2 = x1 + double.Parse(rectData[3]);
                double y2 = y1 + double.Parse(rectData[4]);
                Rectangle rect = new Rectangle(x1, y1, x2, y2);

                Console.WriteLine(kdTree.GetPointsCount(rect, allSpace));
            }

        }
    }
}
