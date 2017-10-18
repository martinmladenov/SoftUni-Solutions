namespace _09.Teamwork_Projects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TeamworkProjects
    {
        public static void Main()
        {
            var teams = new List<Team>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var split = Console.ReadLine().Split('-');
                string creator = split[0];
                string name = split[1];
                if (teams.Any(t => t.Name == name))
                {
                    Console.WriteLine($"Team {name} was already created!");
                    continue;
                }
                if (teams.Any(t => t.CreatorName == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }
                Console.WriteLine($"Team {name} has been created by {creator}!");
                teams.Add(new Team(name, creator));
            }
            string input;
            while ((input = Console.ReadLine()) != "end of assignment")
            {
                var split = input.Split(new[] { '-', '>' },
                    StringSplitOptions.RemoveEmptyEntries);
                string user = split[0];
                string name = split[1];
                var team = teams.FirstOrDefault(t => t.Name == name);
                if (team == null)
                {
                    Console.WriteLine($"Team {name} does not exist!");
                    continue;
                }
                if (teams.Any(t => t.CreatorName == user || t.Members.Contains(user)))
                {
                    Console.WriteLine($"Member {user} cannot join team {name}!");
                    continue;
                }
                team.Members.Add(user);
            }
            foreach (var team in teams
                .Where(t => t.Members.Count > 0)
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.Name))
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.CreatorName}");
                foreach (var teamMember in team.Members
                    .OrderBy(name => name))
                {
                    Console.WriteLine($"-- {teamMember}");
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var teamName in teams
                .Where(t => t.Members.Count == 0)
                .Select(t => t.Name)
                .OrderBy(name => name))
            {
                Console.WriteLine(teamName);
            }
        }
    }

    public class Team
    {
        public string Name;
        public string CreatorName;
        public List<string> Members;

        public Team(string name, string creatorName)
        {
            Name = name;
            CreatorName = creatorName;
            Members = new List<string>();
        }
    }
}
