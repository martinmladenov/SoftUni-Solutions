// ReSharper disable CheckNamespace

public class Square : IFigure
{
    private int side;

    public int Height => side;
    public int Width => side;

    public Square(int side)
    {
        this.side = side;
    }
}
