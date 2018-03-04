public class Rectangle
{
    public Rectangle(int x1, int y1, int width, int height)
    {
        this.X1 = x1;
        this.Y1 = y1;
        this.X2 = x1 + width;
        this.Y2 = y1 + height;
    }

    public int Y1 { get; }

    public int X1 { get; }

    public int Y2 { get; }

    public int X2 { get; }

    public int Width => this.X2 - this.X1;

    public int Height => this.Y2 - this.Y1;

    public int MidX => this.X1 + this.Width / 2;

    public int MidY => this.Y1 + this.Height / 2;

    public bool Intersects(Rectangle other)
    {
        return this.X1 <= other.X2 &&
                other.X1 <= this.X2 &&
                this.Y1 <= other.Y2 &&
                other.Y1 <= this.Y2;
    }

    public bool IsInside(Rectangle other)
    {
        return this.X2 <= other.X2 &&
               this.X1 >= other.X1 &&
               this.Y1 >= other.Y1 &&
               this.Y2 <= other.Y2;
    }

    public override string ToString()
    {
        return $"({this.X1}, {this.Y1}) .. ({this.X2}, {this.Y2})";
    }
}
