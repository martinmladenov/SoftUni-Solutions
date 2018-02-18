using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable CheckNamespace

public class Program
{
    public static void Main()
    {
        var trainers = new Dictionary<string, Trainer>();
        string input;
        while ((input = Console.ReadLine()) != "Tournament")
        {
            var split = input.Split();
            string trainerName = split[0];
            string pokemonName = split[1];
            string pokemonElement = split[2];
            int pokemonHealth = int.Parse(split[3]);

            if (!trainers.ContainsKey(trainerName))
            {
                trainers.Add(trainerName, new Trainer());
            }

            trainers[trainerName].AddPokemon(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
        }

        while ((input = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers.Values)
            {
                trainer.ProcessCommand(input);
            }
        }

        foreach (var trainer in trainers.OrderByDescending(t => t.Value.Badges))
        {
            Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.NumberOfPokemon}");
        }
    }
}
