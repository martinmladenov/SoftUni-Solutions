namespace _04.Winning_Ticket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WinningTicket
    {
        public static void Main()
        {
            var tickets = Console.ReadLine()
                .Split(',')
                .Select(s => s.Trim())
                .ToArray();
            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                Console.Write($"ticket \"{ticket}\" - ");
                var part1Repeats = MaxRepeats(ticket.Substring(0, 10));
                var part2Repeats = MaxRepeats(ticket.Substring(10));
                int amount = part1Repeats
                    .Max(kvp => Math.Min(kvp.Value, part2Repeats[kvp.Key]));
                if (amount < 6)
                {
                    Console.WriteLine("no match");
                    continue;
                }
                char currency = part1Repeats.First(kvp => Math.Min(kvp.Value, part2Repeats[kvp.Key]) == amount).Key;
                Console.WriteLine($"{amount}{currency}" + (amount == 10 ? " Jackpot!" : ""));
            }
        }

        private static Dictionary<char, int> MaxRepeats(string s)
        {
            var maxRepeats = new Dictionary<char, int>
            {
                ['@'] = 0,
                ['#'] = 0,
                ['$'] = 0,
                ['^'] = 0
            };
            char currentRepeatChar = '\0';
            int currentRepeats = 0;
            foreach (var c in s)
            {
                if (currentRepeatChar != c)
                {
                    currentRepeatChar = c;
                    currentRepeats = 0;
                }
                if (!maxRepeats.ContainsKey(c))
                    continue;
                currentRepeats++;
                if (maxRepeats[c] < currentRepeats)
                    maxRepeats[c] = currentRepeats;
            }

            return maxRepeats;
        }
    }
}
