using System;

// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Global
public class LinkedQueue<T>
{
    public int Count { get; private set; }

    private QueueNode<T> _head;
    private QueueNode<T> _tail;

    public LinkedQueue()
    {
        Count = 0;
        _head = _tail = null;
    }

    public void Enqueue(T element)
    {
        var newHead = new QueueNode<T>(element);

        if (Count == 0)
        {
            _tail = newHead;
        }
        else
        {
            newHead.NextNode = _head;
            _head.PrevNode = newHead;
        }

        _head = newHead;

        Count++;
    }

    public T Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }

        var oldTail = _tail;

        _tail = _tail.PrevNode;

        if (Count == 1)
        {
            _head = null;
        }
        else
        {
            _tail.NextNode = null;
        }

        Count--;

        return oldTail.Value;
    }

    public T[] ToArray()
    {
        var arr = new T[Count];

        var currentNode = _tail;

        for (int i = 0; i < Count; i++)
        {
            arr[i] = currentNode.Value;
            currentNode = currentNode.PrevNode;
        }

        return arr;
    }

    private class QueueNode<T>
    {
        public T Value { get; }
        public QueueNode<T> NextNode { get; set; }
        public QueueNode<T> PrevNode { get; set; }

        public QueueNode(T value)
        {
            Value = value;
        }
    }
}
