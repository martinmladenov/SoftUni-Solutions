using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Computer : IComputer
{
    private LinkedList<Invader> byInsertion;
    private OrderedBag<LinkedListNode<Invader>> byPriority;

    public Computer(int energy)
    {
        if (energy < 0)
        {
            throw new ArgumentException();
        }

        Energy = energy;

        byInsertion = new LinkedList<Invader>();
        byPriority = new OrderedBag<LinkedListNode<Invader>>((x, y) => x.Value.CompareTo(y.Value));
    }

    public int Energy { get; private set; }

    public void Skip(int turns)
    {
        var toRemove = new List<LinkedListNode<Invader>>();
        foreach (var node in byPriority)
        {
            var invader = node.Value;

            invader.Distance -= turns;

            if (invader.Distance <= 0)
            {
                if (Energy <= invader.Damage)
                {
                    Energy = 0;
                }
                else
                {
                    Energy -= invader.Damage;
                }

                toRemove.Add(node);
                byInsertion.Remove(node);
            }
        }

        byPriority.RemoveMany(toRemove);
    }

    public void AddInvader(Invader invader)
    {
        var node = byInsertion.AddLast(invader);

        byPriority.Add(node);
    }

    public void DestroyHighestPriorityTargets(int count)
    {
        foreach (var node in byPriority.Take(count).ToArray())
        {
            byInsertion.Remove(node);
            byPriority.Remove(node);
        }
    }

    public void DestroyTargetsInRadius(int radius)
    {
        var toRemove = byPriority.RangeTo(new LinkedListNode<Invader>(new Invader(-1, radius)), false).ToArray();
        foreach (var node in toRemove)
        {
            byInsertion.Remove(node);
        }

        byPriority.RemoveMany(toRemove);
    }

    public IEnumerable<Invader> Invaders()
    {
        return byInsertion;
    }
}