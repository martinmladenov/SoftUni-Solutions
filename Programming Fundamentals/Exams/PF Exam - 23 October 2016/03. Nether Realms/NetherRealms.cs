namespace _03.Nether_Realms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class NetherRealms
    {
        public static void Main()
        {
            var numbersRegex = new Regex(@"[+-]?[\d]+\.?[\d]*");
            var symbolsRegex = new Regex(@"[*/]");
            var lettersRegex = new Regex(@"[^0-9+\-*/.]");
            var demons = new SortedDictionary<string, Demon>();
            foreach (var demon in Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                int health = lettersRegex.Matches(demon)
                    .Cast<Match>()
                    .Aggregate(0, (current, match) => current + char.Parse(match.Value));
                double damage = numbersRegex.Matches(demon)
                    .Cast<Match>()
                    .Sum(match => double.Parse(match.Value));
                damage = symbolsRegex.Matches(demon)
                    .Cast<Match>()
                    .Aggregate(damage, (current, match) => current * (match.Value == "*" ? 2 : 0.5));
                demons[demon] = new Demon(health, damage);
            }
            foreach (var demon in demons)
            {
                Console.WriteLine($"{demon.Key} - {demon.Value.Health} health, {demon.Value.Damage:f2} damage");
            }
        }
    }

    public class Demon
    {
        public int Health { get; }
        public double Damage { get; }

        public Demon(int health, double damage)
        {
            Health = health;
            Damage = damage;
        }
    }
}
