namespace WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
