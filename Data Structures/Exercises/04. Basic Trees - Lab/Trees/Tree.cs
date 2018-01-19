using System;
using System.Collections.Generic;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
public class Tree<T>
{
    public T Value { get; set; }
    public IList<Tree<T>> Children { get; set; }

    public Tree(T value, params Tree<T>[] children)
    {
        Value = value;
        Children = new List<Tree<T>>(children);
    }

    public void Print(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent * 2) + Value);

        foreach (var child in Children)
        {
            child.Print(indent + 1);
        }
    }

    public void Each(Action<T> action)
    {
        action(Value);

        foreach (var child in Children)
        {
            child.Each(action);
        }
    }

    public IEnumerable<T> OrderDFS()
    {
        var list = new List<T>();
        DFSAdd(list);
        return list;
    }

    private void DFSAdd(List<T> list)
    {
        foreach (var child in Children)
        {
            child.DFSAdd(list);
        }

        list.Add(Value);
    }

    public IEnumerable<T> OrderBFS()
    {
        var list = new List<T>();
        var queue = new Queue<Tree<T>>(new[] { this });

        while (queue.Count > 0)
        {
            list.Add(queue.Peek().Value);

            foreach (var child in queue.Dequeue().Children)
            {
                queue.Enqueue(child);
            }
        }

        return list;
    }
}
