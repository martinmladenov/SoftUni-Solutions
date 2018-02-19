using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T> where T : IComparable<T>
{
    private LinkedList<T> byInsertionOrder;
    private OrderedBag<LinkedListNode<T>> byValue;
    private OrderedBag<LinkedListNode<T>> byValueReversed;

    public FirstLastList()
    {
        byInsertionOrder = new LinkedList<T>();
        byValue = new OrderedBag<LinkedListNode<T>>((x, y) => x.Value.CompareTo(y.Value));
        byValueReversed = new OrderedBag<LinkedListNode<T>>((x, y) => y.Value.CompareTo(x.Value));
    }

    public int Count => byInsertionOrder.Count;

    public void Add(T element)
    {
        byInsertionOrder.AddLast(element);
        byValue.Add(byInsertionOrder.Last);
        byValueReversed.Add(byInsertionOrder.Last);
    }

    public void Clear()
    {
        byInsertionOrder.Clear();
        byValue.Clear();
        byValueReversed.Clear();
    }

    public IEnumerable<T> First(int count)
    {
        if (this.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }

        LinkedListNode<T> current = byInsertionOrder.First;

        for (int i = 0; i < count; i++)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    public IEnumerable<T> Last(int count)
    {
        if (this.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }

        LinkedListNode<T> current = byInsertionOrder.Last;

        for (int i = 0; i < count; i++)
        {
            yield return current.Value;
            current = current.Previous;
        }
    }

    public IEnumerable<T> Max(int count)
    {
        if (this.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return byValueReversed.Take(count).Select(node => node.Value);
    }

    public IEnumerable<T> Min(int count)
    {
        if (this.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return byValue.Take(count).Select(node => node.Value);
    }

    public int RemoveAll(T element)
    {
        var node = new LinkedListNode<T>(element);
        foreach (var toRemove in byValue.Range(node, true, node, true))
        {
            byInsertionOrder.Remove(toRemove);
        }

        byValueReversed.RemoveAllCopies(node);
        return byValue.RemoveAllCopies(node);
    }
}
