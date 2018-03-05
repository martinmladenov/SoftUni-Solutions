namespace MassEffectGalaxyMap
{
    public class Rectangle
    {
        public Rectangle(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public double X1 { get; }
        public double Y1 { get; }
        public double X2 { get; }
        public double Y2 { get; }

        public bool Intersects(Rectangle other)
        {
            return this.X1 <= other.X2 &&
                   this.X2 >= other.X1 &&
                   this.Y1 <= other.Y2 &&
                   this.Y2 >= other.Y1;
        }
    }
}
