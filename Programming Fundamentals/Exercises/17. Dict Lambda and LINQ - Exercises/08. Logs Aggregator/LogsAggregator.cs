namespace _08.Logs_Aggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class LogsAggregator
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var ips = new SortedDictionary<string, List<string>>();
            var durations = new SortedDictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                var split = Console.ReadLine().Split();
                string ip = split[0];
                string username = split[1];
                int duration = int.Parse(split[2]);
                if (!ips.ContainsKey(username))
                {
                    ips[username] = new List<string>();
                    durations[username] = 0;
                }
                ips[username].Add(ip);
                durations[username] += duration;
            }
            foreach (var user in ips)
            {
                Console.WriteLine($"{user.Key}: {durations[user.Key]} [{string.Join(", ", user.Value.Distinct().OrderBy(ip => ip))}]");
            }
        }
    }
}
