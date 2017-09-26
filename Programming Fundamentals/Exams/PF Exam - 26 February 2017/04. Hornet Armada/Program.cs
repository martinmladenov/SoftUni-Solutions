using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hornet_Armada
{
    class Program
    {
        static void Main(string[] args)
        {
            //var inputRegex = new Regex(@"^(\d+) = ([^=->,:\s]+) -> ([^=->,:\s]+):(\d+)$");

            long n = long.Parse(Console.ReadLine());

            var legions = new Dictionary<string, Dictionary<string, long>>();
            var activities = new Dictionary<string, long>();

            for (long i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var split = input.Split("=->: ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                long lastActivity = long.Parse(split[0]);
                string legionName = split[1];
                string soldierType = split[2];
                long soldierCount = long.Parse(split[3]);

                if (legions.ContainsKey(legionName))
                {
                    if (legions[legionName].ContainsKey(soldierType))
                        legions[legionName][soldierType] += soldierCount;
                    else
                        legions[legionName][soldierType] = soldierCount;
                    if (activities[legionName] < lastActivity)
                        activities[legionName] = lastActivity;
                }
                else
                {
                    legions[legionName] = new Dictionary<string, long> { [soldierType] = soldierCount };
                    activities[legionName] = lastActivity;
                }

            }

            var endLine = Console.ReadLine();
            if (endLine.Contains("\\"))
            {
                var split = endLine.Split('\\');
                long activity = long.Parse(split[0]);
                var soldierTypeToPrlong = split[1];
                var countByLegion = new Dictionary<string, long>();
                foreach (var legion in legions)
                    if (activities[legion.Key] < activity && legion.Value.ContainsKey(soldierTypeToPrlong))
                        countByLegion[legion.Key] = legion.Value[soldierTypeToPrlong];

                foreach (var kvp in countByLegion.OrderByDescending(lg => lg.Value))
                    Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
            else
            {
                var activitiesByLegion = new Dictionary<string, long>();
                foreach (var legion in legions)
                    if (legion.Value.ContainsKey(endLine))
                        activitiesByLegion[legion.Key] = activities[legion.Key];
                foreach (var kvp in activitiesByLegion.OrderByDescending(lg => lg.Value))
                    Console.WriteLine($"{kvp.Value} : {kvp.Key}");
            }

        }
    }
}
