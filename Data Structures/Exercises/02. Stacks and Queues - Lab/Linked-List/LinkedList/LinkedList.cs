using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    public int Count { get; private set; }

    private Node<T> _head;
    private Node<T> _tail;

    public void AddFirst(T item)
    {
        var newNode = new Node<T>(item) { Next = _head };
        if (Count == 0)
        {
            _tail = newNode;
        }

        _head = newNode;
        Count++;
    }

    public void AddLast(T item)
    {
        var newNode = new Node<T>(item);

        if (Count == 0)
        {
            _head = newNode;
        }
        else
        {
            _tail.Next = newNode;
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

        _head = oldHead.Next;
        Count--;

        if (Count == 0)
        {
            _tail = null;
        }

        return oldHead.Value;
    }

    public T RemoveLast()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }

        Count--;

        var oldTail = _tail;

        if (Count == 0)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            var current = _head;
            while (current.Next != _tail)
            {
                current = current.Next;
            }
            current.Next = null;
            _tail = current;
        }
        return oldTail.Value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; set; }

    public Node(T value)
    {
        Value = value;
    }
}