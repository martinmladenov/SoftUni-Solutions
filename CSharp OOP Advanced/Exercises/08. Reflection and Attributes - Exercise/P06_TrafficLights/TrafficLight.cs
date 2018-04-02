namespace TrafficLights
{
    public class TrafficLight
    {
        public TrafficLight(Color color)
        {
            Color = color;
        }

        public Color Color { get; private set; }

        public void ChangeColor()
        {
            Color = (Color)(((int)Color + 1) % 3);
        }

        public override string ToString()
        {
            return Color.ToString();
        }
    }
}
