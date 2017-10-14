namespace _09.Legendary_Farming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class LegendaryFarming
    {
        public static void Main()
        {
            var materials = new Dictionary<string, int>
            {
                {"shards", 0},
                {"fragments", 0},
                {"motes", 0}
            };
            var junk = new SortedDictionary<string, int>();
            string winner = string.Empty;
            while (winner.Length == 0)
            {
                var split = Console.ReadLine().Split().Select(s => s.ToLower()).ToArray();
                for (int i = 0; i < split.Length; i += 2)
                {
                    string item = split[i + 1];
                    int amount = int.Parse(split[i]);
                    if (item == "shards")
                    {
                        materials["shards"] += amount;
                        if (materials["shards"] < 250) continue;
                        winner = "Shadowmourne";
                        materials["shards"] -= 250;
                        break;
                    }
                    if (item == "fragments")
                    {
                        materials["fragments"] += amount;
                        if (materials["fragments"] < 250) continue;
                        winner = "Valanyr";
                        materials["fragments"] -= 250;
                        break;
                    }
                    if (item == "motes")
                    {
                        materials["motes"] += amount;
                        if (materials["motes"] < 250) continue;
                        winner = "Dragonwrath";
                        materials["motes"] -= 250;
                        break;
                    }
                    if (junk.ContainsKey(item))
                        junk[item] += amount;
                    else
                        junk[item] = amount;
                }
            }
            Console.WriteLine($"{winner} obtained!");
            foreach (var material in materials.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
            foreach (var j in junk)
            {
                Console.WriteLine($"{j.Key}: {j.Value}");
            }
        }
    }
}
