using System;

// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Global
public class LinkedStack<T>
{
    private Node<T> _firstNode;
    public int Count { get; private set; }

    public void Push(T element)
    {
        _firstNode = new Node<T>(element, _firstNode);
        Count++;
    }

    public T Pop()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }

        var value = _firstNode.Value;

        _firstNode = _firstNode.NextNode;
        Count--;

        return value;
    }

    public T[] ToArray()
    {
        var arr = new T[Count];
        var currentNode = _firstNode;

        for (int i = 0; i < Count; i++)
        {
            arr[i] = currentNode.Value;
            currentNode = currentNode.NextNode;
        }

        return arr;
    }

    private class Node<T>
    {
        public T Value { get; }
        public Node<T> NextNode { get; }

        public Node(T value, Node<T> nextNode = null)
        {
            Value = value;
            NextNode = nextNode;
        }
    }
}
