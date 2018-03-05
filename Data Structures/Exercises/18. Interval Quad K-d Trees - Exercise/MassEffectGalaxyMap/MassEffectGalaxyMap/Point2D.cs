using System;
using MassEffectGalaxyMap;

public class Point2D : IComparable<Point2D>
{
    public Point2D(double x, double y)
    {
        this.X = x;
        this.Y = y;
    }

    public double X { get; set; }
    public double Y { get; set; }

    public bool IsInside(Rectangle rectangle)
    {
        return this.X >= rectangle.X1 &&
               this.X <= rectangle.X2 &&
               this.Y >= rectangle.Y1 &&
               this.Y <= rectangle.Y2;
    }

    public override bool Equals(object obj)
    {
        if (obj == this) return true;
        if (obj == null) return false;
        if (obj.GetType() != this.GetType()) return false;
        Point2D that = (Point2D)obj;
        return this.X == that.X && this.Y == that.Y;
    }

    public override int GetHashCode()
    {
        int hashX = this.X.GetHashCode();
        int hashY = this.Y.GetHashCode();
        return 31 * hashX + hashY;
    }

    public int CompareTo(Point2D that)
    {
        if (this.Y < that.Y) return -1;
        if (this.Y > that.Y) return +1;
        if (this.X < that.X) return -1;
        if (this.X > that.X) return +1;
        return 0;
    }
}
