using System;

public class CircularQueue<T>
{
    private T[] _arr;
    private int _readIndex = 0;
    private int _writeIndex = 0;


    private const int DefaultCapacity = 4;

    public int Count { get; private set; }

    public CircularQueue(int capacity = DefaultCapacity)
    {
        _arr = new T[capacity];
    }

    public void Enqueue(T element)
    {
        Count++;
        _arr[_writeIndex] = element;

        _writeIndex = (_writeIndex + 1) % _arr.Length;

        if (_writeIndex == _readIndex)
        {
            GrowArray();
        }
    }

    private void GrowArray()
    {
        var newArr = new T[_arr.Length * 2];
        for (int i = 0; i < _arr.Length; i++)
        {
            newArr[i] = _arr[(_readIndex + i) % _arr.Length];
        }

        _readIndex = 0;
        _writeIndex = _arr.Length;
        _arr = newArr;
    }

    // Should throw InvalidOperationException if the queue is empty
    public T Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }

        Count--;
        T element = _arr[_readIndex];
        _readIndex = (_readIndex + 1) % _arr.Length;
        return element;
    }

    public T[] ToArray()
    {
        int length;
        if (_writeIndex >= _readIndex)
        {
            length = _writeIndex - _readIndex;
        }
        else
        {
            length = _arr.Length - _writeIndex + _readIndex;
        }

        var newArr = new T[length];
        for (int index = _readIndex; index != _writeIndex; index = (index + 1) % _arr.Length)
        {
            newArr[index] = _arr[index];
        }

        return newArr;
    }
}


public class Example
{
    public static void Main()
    {

        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
