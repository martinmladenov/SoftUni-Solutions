namespace MordorsCruelPlan
{
    using Moods;

    public static class MoodFactory
    {
        public static Mood MakeMood(int happinessPoints)
        {
            if (happinessPoints < -5)
            {
                return new AngryMood();
            }

            if (happinessPoints <= 0)
            {
                return new SadMood();
            }

            if (happinessPoints <= 15)
            {
                return new HappyMood();
            }

            return new JavaScriptMood();
        }
    }
}
