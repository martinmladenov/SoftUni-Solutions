namespace WildFarm.Models.Animals.Mammals.Felines
{
    using Foods;

    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightIncrease => 1;

        public override string Sound => "ROAR!!!";

        protected override bool Eats(Food food)
        {
            return food is Meat;
        }
    }
}
