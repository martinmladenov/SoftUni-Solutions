using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var teams = new Dictionary<string, Team>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var split = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
            string command = split[0];

            if (command == "Team")
            {
                try
                {
                    teams.Add(split[1], new Team(split[1]));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (command == "Add")
            {

                string teamName = split[1];
                string playerName = split[2];
                int[] playerStats = split.Skip(3).Select(int.Parse).ToArray();

                if (!teams.ContainsKey(teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist.");
                    continue;
                }

                try
                {
                    teams[teamName].AddPlayer(new Player(playerName, playerStats));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (command == "Remove")
            {
                string teamName = split[1];
                string playerName = split[2];

                if (!teams.ContainsKey(teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist.");
                    continue;
                }

                try
                {
                    teams[teamName].RemovePlayer(playerName);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (command == "Rating")
            {

                string teamName = split[1];

                if (!teams.ContainsKey(teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist.");
                    continue;
                }

                Console.WriteLine(teams[teamName]);
            }
        }

    }
}