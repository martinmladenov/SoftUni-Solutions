namespace _04.Treasure_Map
{
    using System;
    using System.Text.RegularExpressions;

    public class TreasureMap
    {
        public static void Main()
        {
            var instructionRegex = new Regex(@"![^!#]*?\b(?<street>[A-Za-z]{4})\b[^!#]*[^\d](?<number>\d{3})-(?<code>\d{6}|\d{4})(?:[^\d!#][^!#]*)?#|#[^!#]*?\b(?<street>[A-Za-z]{4})\b[^!#]*[^\d](?<number>\d{3})-(?<code>\d{6}|\d{4})(?:[^\d!#][^!#]*)?!");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var matches = instructionRegex.Matches(input);
                var match = matches[matches.Count / 2];
                Console.WriteLine("Go to str. {0} {1}. Secret pass: {2}.",
                    match.Groups["street"].Value, match.Groups["number"].Value, match.Groups["code"].Value);
            }
        }
    }
}
