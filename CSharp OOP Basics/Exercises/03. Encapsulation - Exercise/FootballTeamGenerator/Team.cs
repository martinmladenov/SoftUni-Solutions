using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private List<Player> players;

    public Team(string name)
    {
        Name = name;
        players = new List<Player>();
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

    public int Rating
    {
        get
        {
            if (players.Count == 0)
            {
                return 0;
            }

            return (int)Math.Round(players.Average(p => p.SkillLevel));
        }
    }

    public void AddPlayer(Player p)
    {
        players.Add(p);
    }

    public void RemovePlayer(string name)
    {
        if (players.RemoveAll(p => p.Name == name) == 0)
        {
            throw new ArgumentException($"Player {name} is not in {Name} team.");
        }
    }

    public override string ToString()
    {
        return $"{Name} - {Rating}";
    }
}
