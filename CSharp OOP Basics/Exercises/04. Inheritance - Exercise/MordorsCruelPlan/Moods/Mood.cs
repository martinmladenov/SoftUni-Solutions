namespace MordorsCruelPlan.Moods
{
    public abstract class Mood
    {
        protected Mood(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
