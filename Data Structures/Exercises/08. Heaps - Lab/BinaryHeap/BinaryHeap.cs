using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> _heap;

    public BinaryHeap()
    {
        _heap = new List<T>();
    }

    public int Count => _heap.Count;

    public void Insert(T item)
    {
        _heap.Add(item);
        HeapifyUp(Count - 1);
    }

    private void HeapifyUp(int index)
    {
        while (index > 0 && IsLess(Parent(index), index))
        {
            Swap(index, Parent(index));
            index = Parent(index);
        }
    }

    private void Swap(int i1, int i2)
    {
        T oldFirst = _heap[i1];
        _heap[i1] = _heap[i2];
        _heap[i2] = oldFirst;
    }

    private bool IsLess(int i1, int i2)
    {
        return _heap[i1].CompareTo(_heap[i2]) == -1;
    }

    private int Parent(int index)
    {
        return (index - 1) / 2;
    }

    public T Peek()
    {
        return _heap[0];
    }

    public T Pull()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }

        T item = _heap[0];
        Swap(0, Count - 1);
        _heap.RemoveAt(Count - 1);
        HeapifyDown(0);

        return item;
    }

    private void HeapifyDown(int index)
    {
        while (index < Count / 2)
        {
            int child = Left(index);
            if (HasChild(child + 1) && IsLess(child, child + 1))
            {
                child++;
            }

            if (IsLess(child, index))
            {
                break;
            }

            Swap(index, child);
            index = child;
        }
    }

    private bool HasChild(int index)
    {
        return Count > 2 * index + 1;
    }

    private int Left(int index)
    {
        return 2 * index + 1;
    }
}
