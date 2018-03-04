namespace WildFarm.Models.Animals.Birds
{
    using Animals;

    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double WeightIncrease => 0.35;

        public override string Sound => "Cluck";

        protected override bool Eats(Food food)
        {
            return true;
        }
    }
}
