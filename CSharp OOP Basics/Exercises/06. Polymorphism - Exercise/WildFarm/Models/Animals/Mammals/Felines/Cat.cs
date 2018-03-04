namespace WildFarm.Models.Animals.Mammals.Felines
{
    using Foods;

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion,
            breed)
        {
        }

        public override double WeightIncrease => 0.3;

        public override string Sound => "Meow";

        protected override bool Eats(Food food)
        {
            return food is Vegetable ||
                   food is Meat;
        }
    }
}
