using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
public class DoublyLinkedList<T> : IEnumerable<T>
{
    private class ListNode<T>
    {
        public T Value { get; }
        public ListNode<T> PrevNode { get; set; }
        public ListNode<T> NextNode { get; set; }

        public ListNode(T value)
        {
            Value = value;
        }
    }

    private ListNode<T> _head;
    private ListNode<T> _tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        var newNode = new ListNode<T>(element);
        newNode.NextNode = _head;

        if (Count == 0)
        {
            _tail = newNode;
        }
        else
        {
            _head.PrevNode = newNode;
        }

        _head = newNode;

        Count++;
    }

    public void AddLast(T element)
    {
        var newNode = new ListNode<T>(element);
        newNode.PrevNode = _tail;

        if (Count == 0)
        {
            _head = newNode;
        }
        else
        {
            _tail.NextNode = newNode;
        }

        _tail = newNode;
        Count++;
    }

    public T RemoveFirst()
    {

        if (Count == 0)
        {
            throw new InvalidOperationException();
        }

        var oldHead = _head;

        if (Count == 1)
            _head = _tail = null;
        else
        {
            _head = _head.NextNode;
            _head.PrevNode = null;
        }

        Count--;

        return oldHead.Value;
    }

    public T RemoveLast()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }

        var oldTail = _tail;

        if (Count == 1)
        {
            _head = _tail = null;
        }
        else
        {
            _tail = _tail.PrevNode;
            _tail.NextNode = null;
        }

        Count--;

        return oldTail.Value;
    }

    public void ForEach(Action<T> action)
    {
        var node = _head;
        while (node != null)
        {
            action(node.Value);
            node = node.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var node = _head;
        while (node != null)
        {
            yield return node.Value;
            node = node.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public T[] ToArray()
    {
        var arr = new T[Count];
        var node = _head;
        for (int i = 0; node != null; i++)
        {
            arr[i] = node.Value;
            node = node.NextNode;
        }

        return arr;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
