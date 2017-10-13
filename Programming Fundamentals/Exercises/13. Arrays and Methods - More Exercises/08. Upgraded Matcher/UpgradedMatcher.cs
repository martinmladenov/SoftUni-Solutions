namespace _08.Upgraded_Matcher
{
    using System;
    using System.Linq;

    public static class UpgradedMatcher
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split().ToList();
            var quantities = Console.ReadLine().Split().Select(long.Parse).ToList();
            var prices = Console.ReadLine().Split().Select(double.Parse).ToList();
            string input;
            while ((input = Console.ReadLine()) != "done")
            {
                var split = input.Split();
                int index = names.IndexOf(split[0]);
                long quantity = long.Parse(split[1]);
                if (quantities.Count <= index || quantities[index] < quantity)
                {
                    Console.WriteLine($"We do not have enough {split[0]}");
                    continue;
                }
                quantities[index] -= quantity;
                Console.WriteLine($"{split[0]} x {quantity} costs {prices[index] * quantity:f2}");
            }
        }
    }
}
