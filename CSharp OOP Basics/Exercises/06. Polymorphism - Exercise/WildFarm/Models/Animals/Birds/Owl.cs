namespace WildFarm.Models.Animals.Birds
{
    using Animals;
    using Foods;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double WeightIncrease => 0.25;

        public override string Sound => "Hoot Hoot";

        protected override bool Eats(Food food)
        {
            return food is Meat;
        }
    }
}
