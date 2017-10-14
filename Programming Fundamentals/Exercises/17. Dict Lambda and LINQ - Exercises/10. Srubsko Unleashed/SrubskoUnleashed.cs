namespace _10.Srubsko_Unleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class SrubskoUnleashed
    {
        public static void Main()
        {
            var venues = new Dictionary<string, Dictionary<string, long>>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                bool failed = true;
                var split = input.Split();
                int startIndex = 0;
                string singer = string.Empty;
                for (int i = 0; i <= 3 && i < split.Length; i++) // name
                {
                    string part = split[i];
                    if (part[0] == '@')
                    {
                        if (i != 0)
                        {
                            startIndex = i;
                            failed = false;
                        }
                        break;
                    }
                    singer += " " + part;
                }
                if (failed) continue;
                singer = singer.Substring(1);
                failed = true;
                string venue = string.Empty;
                int ticketsPrice = 0;
                for (int i = startIndex; i <= 3 + startIndex && i < split.Length; i++) // venue
                {
                    string part = split[i];
                    if (int.TryParse(part, out ticketsPrice))
                    {
                        failed = false;
                        startIndex = i + 1;
                        break;
                    }
                    venue += " " + part;
                }
                if (split.Length < startIndex + 1 ||
                failed ||
                    !int.TryParse(split[startIndex], out int ticketsCount))
                    continue;
                venue = venue.Substring(2);
                if (!venues.ContainsKey(venue))
                    venues[venue] = new Dictionary<string, long>();
                if (!venues[venue].ContainsKey(singer))
                    venues[venue][singer] = 0;
                venues[venue][singer] += ticketsPrice * ticketsCount;
            }
            foreach (var venue in venues)
            {
                Console.WriteLine(venue.Key);
                foreach (var singer in venue.Value.OrderByDescending(kvp => kvp.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
