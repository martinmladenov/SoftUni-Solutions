namespace _03.Greedy_Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GreedyTimes
    {
        public static void Main()
        {
            long capacity = long.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var items = new Dictionary<string, Dictionary<string, long>>
            {
                {"Gold", new Dictionary<string, long>() },
                {"Gem", new Dictionary<string, long>() },
                {"Cash", new Dictionary<string, long>() }
            };

            var gold = items["Gold"];
            var gems = items["Gem"];
            var cash = items["Cash"];

            for (int i = 0; i < input.Length; i += 2)
            {
                string item = input[i];
                long amount = long.Parse(input[i + 1]);
                if (gold.Sum(kvp => kvp.Value)
                    + gems.Sum(kvp => kvp.Value)
                    + cash.Sum(kvp => kvp.Value)
                    + amount > capacity)
                    continue;
                if (item.ToLower() == "gold")
                {
                    if (gold.ContainsKey(item))
                        gold[item] += amount;
                    else
                        gold[item] = amount;
                }
                else if (item.ToLower().EndsWith("gem") && item.Length >= 4
                    && gems.Sum(kvp => kvp.Value) + amount
                    <= gold.Sum(kvp => kvp.Value))
                {
                    if (gems.ContainsKey(item))
                        gems[item] += amount;
                    else
                        gems[item] = amount;
                }
                else if (item.Length == 3 &&
                         cash.Sum(kvp => kvp.Value) + amount
                            <= gems.Sum(kvp => kvp.Value))
                {
                    if (cash.ContainsKey(item))
                        cash[item] += amount;
                    else
                        cash[item] = amount;
                }
            }

            foreach (var item in items
                .Where(item =>
                    item.Value.Count > 0)
                .OrderByDescending(item =>
                item.Value.Sum(kvp => kvp.Value)))
            {
                Console.WriteLine("<{0}> ${1}",
                    item.Key,
                    item.Value.Sum(kvp => kvp.Value));
                foreach (var kvp in item.Value
                    .OrderByDescending(kvp => kvp.Key)
                    .ThenBy(kvp => kvp.Value))
                {
                    Console.WriteLine($"##{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}
