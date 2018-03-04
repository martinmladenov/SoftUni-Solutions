namespace SweepAndPrune
{
    public class GameObject
    {
        public GameObject(string name, int x1, int y1)
        {
            this.Name = name;
            this.MoveTo(x1, y1);
        }

        public string Name { get; }
        public Rectangle PositionBox { get; private set; }

        public void MoveTo(int x1, int y1)
        {
            this.PositionBox = new Rectangle(x1, y1, x1 + 10, y1 + 10);
        }

        public bool CollidesWith(GameObject other)
        {
            return this.PositionBox.Intersects(other.PositionBox);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
