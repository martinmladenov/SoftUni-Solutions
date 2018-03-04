namespace WildFarm.Models.Animals.Mammals
{
    using Animals;
    using Foods;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double WeightIncrease => 0.4;

        public override string Sound => "Woof!";

        protected override bool Eats(Food food)
        {
            return food is Meat;
        }
    }
}
