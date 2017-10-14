namespace _11.Dragon_Army
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DragonArmy
    {
        public static void Main()
        {
            var dragonColors = new Dictionary<string, SortedDictionary<string, DragonStats>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var split = Console.ReadLine().Split();
                string color = split[0];
                string name = split[1];
                if (!int.TryParse(split[2], out int damage))
                    damage = 45;
                if (!int.TryParse(split[3], out int health))
                    health = 250;
                if (!int.TryParse(split[4], out int armor))
                    armor = 10;

                if (!dragonColors.ContainsKey(color))
                    dragonColors[color] = new SortedDictionary<string, DragonStats>();
                dragonColors[color][name] = new DragonStats(damage, health, armor);
            }
            foreach (var color in dragonColors)
            {
                double averageDamage = color.Value
                    .Values
                    .Select(stats => stats.Damage)
                    .Average();
                double averageHealth = color.Value
                    .Values
                    .Select(stats => stats.Health)
                    .Average();
                double averageArmor = color.Value
                    .Values
                    .Select(stats => stats.Armor)
                    .Average();
                Console.WriteLine($"{color.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");
                foreach (var dragon in color.Value)
                {
                    int damage = dragon.Value.Damage;
                    int health = dragon.Value.Health;
                    int armor = dragon.Value.Armor;
                    Console.WriteLine($"-{dragon.Key} -> damage: {damage}, health: {health}, armor: {armor}");
                }
            }
        }
    }

    public class DragonStats
    {
        public int Damage { get; }
        public int Health { get; }
        public int Armor { get; }

        public DragonStats(int damage, int health, int armor)
        {
            Damage = damage;
            Health = health;
            Armor = armor;
        }
    }
}
