namespace WildFarm.Models.Animals.Mammals
{
    using Animals;
    using Foods;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double WeightIncrease => 0.1;

        public override string Sound => "Squeak";

        protected override bool Eats(Food food)
        {
            return food is Vegetable ||
                   food is Fruit;
        }
    }
}
