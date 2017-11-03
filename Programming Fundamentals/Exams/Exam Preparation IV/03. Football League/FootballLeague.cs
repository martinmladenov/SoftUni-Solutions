namespace _03.Football_League
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FootballLeague
    {
        public static void Main()
        {
            string key = Console.ReadLine();
            var points = new Dictionary<string, int>();
            var goals = new Dictionary<string, int>();
            string[] input;
            while ((input = Console.ReadLine().Split())[0] != "final")
            {
                string teamA = DecryptTeam(input[0], key);
                string teamB = DecryptTeam(input[1], key);
                RegisterTeam(teamA, points, goals);
                RegisterTeam(teamB, points, goals);
                int goalsA = int.Parse(input[2].Split(':')[0]);
                int goalsB = int.Parse(input[2].Split(':')[1]);
                goals[teamA] += goalsA;
                goals[teamB] += goalsB;
                if (goalsA > goalsB)
                    points[teamA] += 3;
                else if (goalsA < goalsB)
                    points[teamB] += 3;
                else
                {
                    points[teamA]++;
                    points[teamB]++;
                }
            }
            Console.WriteLine("League standings:");
            int cnt = 1;
            foreach (var team in points
                .OrderByDescending(team => team.Value)
                .ThenBy(team => team.Key))
            {
                Console.WriteLine($"{cnt++}. {team.Key} {team.Value}");
            }
            Console.WriteLine("Top 3 scored goals:");
            foreach (var team in goals
                .OrderByDescending(team => team.Value)
                .ThenBy(team => team.Key)
                .Take(3))
            {
                Console.WriteLine($"- {team.Key} -> {team.Value}");
            }
        }

        private static void RegisterTeam(string team, Dictionary<string, int> points, Dictionary<string, int> goals)
        {
            if (points.ContainsKey(team)) return;
            points.Add(team, 0);
            goals.Add(team, 0);
        }

        private static string DecryptTeam(string team, string key)
            => string.Join("", team.Substring(team.IndexOf(key)).Split(new[] { key }, StringSplitOptions.None)[1].Reverse()).ToUpper();
    }
}
