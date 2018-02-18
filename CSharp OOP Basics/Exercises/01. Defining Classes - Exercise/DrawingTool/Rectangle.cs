// ReSharper disable CheckNamespace

public class Rectangle : IFigure
{
    public int Width { get; }
    public int Height { get; }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }
}
