using System;
using System.Collections.Generic;
using MassEffectGalaxyMap;

public class KdTree
{
    private Node root;

    public class Node
    {
        public Node(Point2D point)
        {
            this.Point = point;
        }

        public Point2D Point { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    public Node Root => this.root;

    public bool Contains(Point2D point)
    {
        return Search(this.root, point, 0) != null;
    }

    public int GetPointsCount(Rectangle rectangle, Rectangle space)
    {
        int count = 0;
        this.GetPointsCount(this.Root, ref count, rectangle, space, 0);
        return count;
    }

    private void GetPointsCount(Node node, ref int count, Rectangle rectangle, Rectangle space, int depth)
    {
        if (node == null)
        {
            return;
        }

        if (node.Point.IsInside(rectangle))
        {
            count++;
        }

        Rectangle leftRect;
        Rectangle rightRect;

        if (depth % 2 == 0)
        {
            leftRect = new Rectangle(space.X1, space.Y1, node.Point.X, space.Y2);
            rightRect = new Rectangle(node.Point.X, space.Y1, space.X2, space.Y2);
        }
        else
        {
            leftRect = new Rectangle(space.X1, space.Y1, space.X2, node.Point.Y);
            rightRect = new Rectangle(space.X1, node.Point.Y, space.X2, space.Y2);
        }

        if (rectangle.Intersects(leftRect))
        {
            this.GetPointsCount(node.Left, ref count, rectangle, leftRect, depth + 1);
        }

        if (rectangle.Intersects(rightRect))
        {
            this.GetPointsCount(node.Right, ref count, rectangle, rightRect, depth + 1);
        }
    }

    public void Insert(Point2D point)
    {
        this.root = this.Insert(this.root, point, 0);
    }

    private Node Insert(Node node, Point2D point, int depth)
    {
        if (node == null)
        {
            return new Node(point);
        }

        if (depth % 2 == 0)
        {
            if (node.Point.X.CompareTo(point.X) > 0)
            {
                node.Left = this.Insert(node.Left, point, depth + 1);
            }
            else
            {
                node.Right = this.Insert(node.Right, point, depth + 1);
            }
        }
        else
        {
            if (node.Point.Y.CompareTo(point.Y) > 0)
            {
                node.Left = this.Insert(node.Left, point, depth + 1);
            }
            else
            {
                node.Right = this.Insert(node.Right, point, depth + 1);
            }
        }
        return node;
    }

    private Node Search(Node node, Point2D point, int depth)
    {
        if (node == null)
        {
            return null;
        }

        int cmp;
        if (depth % 2 == 0)
        {
            cmp = point.X.CompareTo(node.Point.X);

            if (cmp == 0)
            {
                cmp = point.Y.CompareTo(node.Point.Y);
            }
        }
        else
        {
            cmp = point.Y.CompareTo(node.Point.Y);

            if (cmp == 0)
            {
                cmp = point.X.CompareTo(node.Point.X);
            }
        }

        if (cmp < 0)
        {
            return Search(node.Left, point, depth + 1);
        }

        if (cmp > 0)
        {
            return Search(node.Right, point, depth + 1);
        }

        return node;
    }

    public void EachInOrder(Action<Point2D> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<Point2D> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Point);
        this.EachInOrder(node.Right, action);
    }

    public static KdTree FromList(List<Point2D> systems)
    {
        KdTree kdTree = new KdTree();
        kdTree.root = kdTree.Build(systems);
        return kdTree;
    }

    private Node Build(List<Point2D> systems, int depth = 0)
    {

        if (systems.Count == 0)
        {
            return null;
        }

        int axis = depth % 2;
        systems.Sort((x, y) =>
        {
            if (axis == 0)
            {
                return x.X.CompareTo(y.X);
            }
            return x.Y.CompareTo(y.Y);
        });

        int median = systems.Count / 2;
        List<Point2D> left = new List<Point2D>();
        List<Point2D> right = new List<Point2D>();

        for (int i = 0; i < median; i++)
        {
            left.Add(systems[i]);
        }
        for (int i = median + 1; i < systems.Count; i++)
        {
            right.Add(systems[i]);
        }

        Node newNode = new Node(systems[median])
        {
            Left = this.Build(left, depth + 1),
            Right = this.Build(right, depth + 1)
        };
        return newNode;
    }

}
