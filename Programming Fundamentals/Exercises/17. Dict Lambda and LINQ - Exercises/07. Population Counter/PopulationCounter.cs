namespace _07.Population_Counter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class PopulationCounter
    {
        public static void Main()
        {
            var countries = new Dictionary<string, Dictionary<string, long>>();
            string input;
            while ((input = Console.ReadLine()) != "report")
            {
                var split = input.Split('|');
                string city = split[0];
                string country = split[1];
                long population = long.Parse(split[2]);
                if (!countries.ContainsKey(country))
                    countries[country] = new Dictionary<string, long>();
                countries[country][city] = population;
            }
            foreach (var country in countries.OrderByDescending(kvp1 => kvp1.Value.Sum(kvp2 => kvp2.Value)))
            {
                long totalPopulation = country.Value.Sum(kvp => kvp.Value);
                Console.WriteLine($"{country.Key} (total population: {totalPopulation})");
                foreach (var city in country.Value.OrderByDescending(kvp => kvp.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
