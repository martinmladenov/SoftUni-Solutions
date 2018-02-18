// ReSharper disable CheckNamespace

using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    public int Badges { get; private set; }
    private List<Pokemon> pokemon;

    public int NumberOfPokemon => pokemon.Count;

    public Trainer()
    {
        Badges = 0;
        pokemon = new List<Pokemon>();
    }

    public void AddPokemon(Pokemon toAdd)
    {
        this.pokemon.Add(toAdd);
    }

    public void ProcessCommand(string element)
    {
        if (pokemon.Any(p => p.Element == element))
        {
            Badges++;
            return;
        }

        pokemon.RemoveAll(p => (p.Health -= 10) <= 0);
    }
}