namespace MordorsCruelPlan
{
    using Foods;
    using Moods;

    public class Gandalf
    {
        public int HappinessPoints { get; private set; }

        public void Eat(string foodName)
        {
            Food food = FoodFactory.MakeFood(foodName);
            HappinessPoints += food.HappinessPoints;
        }

        public Mood Mood => MoodFactory.MakeMood(HappinessPoints);

    }
}
