using System;

public class ArrayList<T>
{
    public int Count { get; private set; }

    private T[] _array;

    public ArrayList()
    {
        _array = new T[2];
        Count = 0;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _array[index];
        }

        set
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            _array[index] = value;
        }
    }

    public void Add(T item)
    {
        if (_array.Length <= Count)
        {
            var newArr = new T[Count * 2];
            Array.Copy(_array, newArr, Count);
            _array = newArr;
        }

        _array[Count] = item;

        Count++;
    }

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        var element = _array[index];

        Count--;

        for (int i = index; i < Count; i++)
        {
            _array[i] = _array[i + 1];
        }

        return element;
    }
}
