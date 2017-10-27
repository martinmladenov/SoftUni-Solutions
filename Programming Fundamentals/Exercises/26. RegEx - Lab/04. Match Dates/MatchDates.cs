namespace _04.Match_Dates
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchDates
    {
        public static void Main()
        {
            var rgx = new Regex(@"\b(?<day>\d{2})([\/.-])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b");
            var dates = Console.ReadLine();
            foreach (Match match in rgx.Matches(dates))
                Console.WriteLine(
                    $"Day: {match.Groups["day"].Value}, Month: {match.Groups["month"].Value}, Year: {match.Groups["year"]}");
        }
    }
}
