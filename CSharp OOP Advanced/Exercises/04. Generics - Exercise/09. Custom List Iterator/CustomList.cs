using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> : IEnumerable<T>
     where T : IComparable<T>
{
    private List<T> list;

    public CustomList()
    {
        list = new List<T>();
    }

    public void Add(T element)
    {
        list.Add(element);
    }

    public T Remove(int index)
    {
        T removed = list[index];
        list.RemoveAt(index);
        return removed;
    }

    public bool Contains(T element)
    {
        return list.Contains(element);
    }

    public void Swap(int i1, int i2)
    {
        T tmp = list[i1];
        list[i1] = list[i2];
        list[i2] = tmp;
    }

    public int CountGreaterThen(T element)
    {
        return list.Count(x => x.CompareTo(element) > 0);
    }

    public T Max()
    {
        return list.Max();
    }

    public T Min()
    {
        return list.Min();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
