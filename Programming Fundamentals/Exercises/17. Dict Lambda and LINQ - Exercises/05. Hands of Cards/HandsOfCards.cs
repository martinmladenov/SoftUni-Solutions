namespace _05.Hands_of_Cards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class HandsOfCards
    {
        public static void Main()
        {
            var cards = new Dictionary<string, List<string>>();
            string input;
            while ((input = Console.ReadLine()) != "JOKER")
            {
                var split = input.Substring(input.IndexOf(':') + 1).Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string name = input.Substring(0, input.IndexOf(':'));
                if (!cards.ContainsKey(name))
                    cards[name] = new List<string>();
                foreach (string t in split)
                {
                    cards[name].Add(t);
                }
            }
            foreach (var kvp in cards)
            {
                long score = 0;
                foreach (var s in kvp.Value.Distinct())
                {
                    score += GetCardValue(s);
                }
                Console.WriteLine($"{kvp.Key}: {score}");
            }
        }

        private static int GetCardValue(string card)
        {
            string power = card.Substring(0, card.Length - 1);
            char type = card[card.Length - 1];
            int value;
            switch (power)
            {
                case "J":
                    value = 11;
                    break;

                case "Q":
                    value = 12;
                    break;

                case "K":
                    value = 13;
                    break;

                case "A":
                    value = 14;
                    break;

                default:
                    value = int.Parse(power);
                    break;
            }

            switch (type)
            {
                case 'S':
                    value *= 4;
                    break;

                case 'H':
                    value *= 3;
                    break;

                case 'D':
                    value *= 2;
                    break;
            }
            return value;
        }
    }
}
