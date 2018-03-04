namespace SweepAndPrune
{
    public class Rectangle
    {
        public Rectangle(int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public int X1 { get; }
        public int Y1 { get; }
        public int X2 { get; }
        public int Y2 { get; }

        public bool Intersects(Rectangle other)
        {
            return this.X1 < other.X2 &&
                   this.X2 > other.X1 &&
                   this.Y1 < other.Y2 &&
                   this.Y2 > other.Y1;
        }
    }
}
