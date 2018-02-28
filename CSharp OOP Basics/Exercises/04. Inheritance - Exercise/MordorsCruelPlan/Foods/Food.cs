namespace MordorsCruelPlan.Foods
{
    public abstract class Food
    {
        protected Food(int happinessPoints)
        {
            HappinessPoints = happinessPoints;
        }

        public int HappinessPoints { get; }
    }
}
