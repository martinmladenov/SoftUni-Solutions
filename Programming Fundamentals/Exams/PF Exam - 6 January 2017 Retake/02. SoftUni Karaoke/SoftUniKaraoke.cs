namespace _02.SoftUni_Karaoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniKaraoke
    {
        public static void Main()
        {
            var participants = Console.ReadLine().Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .ToArray();
            var songs = Console.ReadLine().Split(new[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .ToArray();
            var awards = new Dictionary<string, List<string>>();
            string input;
            while ((input = Console.ReadLine()) != "dawn")
            {
                var performance = input.Split(new[] { ',' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .ToArray();
                string participant = performance[0];
                string song = performance[1];
                string award = performance[2];
                if (!songs.Contains(song) || !participants.Contains(participant))
                    continue;
                if (!awards.ContainsKey(participant))
                    awards[participant] = new List<string>();
                else if (awards[participant].Contains(award))
                    continue;
                awards[participant].Add(award);
            }
            if (awards.Count > 0)
            {
                foreach (var participant in awards
                    .OrderByDescending(kvp => kvp.Value.Count)
                    .ThenBy(kvp => kvp.Key))
                {
                    Console.WriteLine($"{participant.Key}: {participant.Value.Count} awards");
                    foreach (var award in participant.Value.OrderBy(a => a))
                    {
                        Console.WriteLine($"--{award}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No awards");
            }
        }
    }
}
