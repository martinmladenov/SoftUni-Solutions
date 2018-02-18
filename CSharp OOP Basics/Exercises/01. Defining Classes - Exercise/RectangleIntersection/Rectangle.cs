// ReSharper disable CheckNamespace
public class Rectangle
{
    public double Width { get; }
    public double Height { get; }
    public double X { get; }
    public double Y { get; }

    public Rectangle(double width, double height, double x, double y)
    {
        Width = width;
        Height = height;
        X = x;
        Y = y;
    }

    public bool Intersects(Rectangle other)
    {
        return X >= other.X && X <= other.X + other.Width
                            && Y >= other.Y && Y <= other.Y + other.Height ||
               X + Width >= other.X && X + Width <= other.X + other.Width
                                    && Y >= other.Y && Y <= other.Y + other.Height ||
               X >= other.X && X <= other.X + other.Width
                            && Y + Height >= other.Y && Y + Height <= other.Y + other.Height ||
               X + Width >= other.X && X + Width <= other.X + other.Width
                                    && Y + Height >= other.Y && Y + Height <= other.Y + other.Height;


    }
}
