using System;

// ReSharper disable UnusedMember.Global
// ReSharper disable CheckNamespace
public class ArrayStack<T>
{
    private T[] _elements;
    public int Count { get; private set; }
    private const int InitialCapacity = 16;

    public ArrayStack(int capacity = InitialCapacity)
    {
        _elements = new T[capacity];
        Count = 0;
    }

    public void Push(T element)
    {
        if (Count >= _elements.Length)
        {
            Grow();
        }

        _elements[Count++] = element;
    }

    public T Pop()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }

        var element = _elements[--Count];
        _elements[Count] = default(T);
        return element;
    }

    public T[] ToArray()
    {
        var arr = new T[Count];
        for (int i = 0; i < Count; i++)
        {
            arr[i] = _elements[Count - i - 1];
        }

        return arr;
    }

    private void Grow()
    {
        var newArray = new T[_elements.Length * 2];
        Array.Copy(_elements, newArray, Count);
        _elements = newArray;
    }
}