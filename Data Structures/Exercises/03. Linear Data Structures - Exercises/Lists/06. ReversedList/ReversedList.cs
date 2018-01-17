using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
public class ReversedList<T> : IEnumerable<T>
{
    private T[] _arr;

    public int Count { get; private set; }

    public int Capacity => _arr.Length;

    public ReversedList()
    {
        _arr = new T[2];
    }

    public void Add(T item)
    {
        if (Count == Capacity)
        {
            var newArr = new T[Capacity * 2];
            Array.Copy(_arr, newArr, Count);
            _arr = newArr;
        }

        _arr[Count++] = item;
    }

    public T this[int index]
    {
        get => _arr[Count - 1 - index];

        set => _arr[Count - 1 - index] = value;
    }

    public void RemoveAt(int index)
    {
        for (int i = Count - index + 1; i < Count; i++)
        {
            _arr[i - 1] = _arr[i];
        }

        Count--;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = Count - 1; i >= 0; i--)
        {
            yield return _arr[i];
        }
    }
}