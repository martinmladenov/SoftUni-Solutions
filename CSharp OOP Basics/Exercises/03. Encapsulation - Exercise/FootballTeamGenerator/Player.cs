using System;
using System.Linq;

public class Player
{
    private string name;
    private int[] stats;

    public Player(string name, int[] stats)
    {
        Name = name;
        Stats = stats;
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            name = value;
        }
    }

    public double SkillLevel => Stats.Average();

    public int[] Stats
    {
        get => stats;
        set
        {
            string[] statNames = { "Endurance", "Sprint", "Dribble", "Passing", "Shooting" };

            for (int i = 0; i < 5; i++)
            {
                if (value[i] < 0 || value[i] > 100)
                {
                    throw new ArgumentException($"{statNames[i]} should be between 0 and 100.");
                }
            }
            stats = value;
        }
    }
}
