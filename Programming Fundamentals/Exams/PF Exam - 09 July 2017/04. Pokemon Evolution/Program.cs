namespace _04.Pokemon_Evolution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var pokemons = new Dictionary<string, List<Evolution>>();
            var rgx = new Regex(@"^(?:([^->\s]+)\s->\s){2}([\d]+)$");

            string input;
            while ((input = Console.ReadLine()) != "wubbalubbadubdub")
            {
                if (rgx.IsMatch(input))
                {
                    var groups = rgx.Matches(input)[0].Groups;
                    var name = groups[1].Captures[0].Value;
                    var evolutionType = groups[1].Captures[1].Value;
                    var evolutionIndex = int.Parse(groups[2].Captures[0].Value);
                    List<Evolution> evolutions;
                    if (pokemons.ContainsKey(name))
                    {
                        evolutions = pokemons[name];
                    }
                    else
                    {
                        evolutions = new List<Evolution>();
                        pokemons[name] = evolutions;
                    }
                    evolutions.Add(new Evolution(evolutionType, evolutionIndex));
                }
                else if (pokemons.ContainsKey(input))
                    PrintPokemon(input, pokemons[input], false);
            }
            foreach (var pokemon in pokemons)
            {
                PrintPokemon(pokemon.Key, pokemon.Value, true);
            }
        }

        private static void PrintPokemon(string name, List<Evolution> evolutions, bool descending)
        {
            Console.WriteLine($"# {name}");
            if (descending)
                evolutions = evolutions.OrderByDescending(e => e.EvolutionIndex).ToList();
            foreach (var evolution in evolutions)
            {
                Console.WriteLine($"{evolution.EvolutionType} <-> {evolution.EvolutionIndex}");
            }
        }
    }

    public class Evolution
    {
        public string EvolutionType { get; }
        public int EvolutionIndex { get; }

        public Evolution(string evolutionType, int evolutionIndex)
        {
            EvolutionType = evolutionType;
            EvolutionIndex = evolutionIndex;
        }
    }
}
