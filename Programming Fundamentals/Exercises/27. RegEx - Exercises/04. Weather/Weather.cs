namespace _04.Weather
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Weather
    {
        public static void Main()
        {
            var rgx = new Regex(@"(?<code>[A-Z]{2})(?<temp>\d+\.\d+)(?<type>[A-Za-z]+)\|");
            var temps = new Dictionary<string, double>();
            var weather = new Dictionary<string, string>();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                foreach (Match match in rgx.Matches(input))
                {
                    temps[match.Groups["code"].Value] = double.Parse(match.Groups["temp"].Value);
                    weather[match.Groups["code"].Value] = match.Groups["type"].Value;
                }
            }
            foreach (var city in temps.OrderBy(city => city.Value))
            {
                Console.WriteLine($"{city.Key} => {city.Value:f2} => {weather[city.Key]}");
            }
        }
    }
}
