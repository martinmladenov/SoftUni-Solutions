using System;

// ReSharper disable CheckNamespace
public static class Heap<T> where T : IComparable<T>
{
    public static void Sort(T[] arr)
    {
        int n = arr.Length;
        for (int i = n / 2; i >= 0; i--)
        {
            HeapifyDown(i, n, arr);
        }

        for (int i = n - 1; i > 0; i--)
        {
            Swap(0, i, arr);
            HeapifyDown(0, i, arr);
        }
    }

    private static void HeapifyDown(int current, int border, T[] arr)
    {
        while (current < border / 2)
        {
            int greaterChild = 2 * current + 1;
            if (border > greaterChild + 1 &&
                arr[greaterChild].CompareTo(arr[greaterChild+1]) == -1)
            {
                greaterChild++;
            }

            if (arr[current].CompareTo(arr[greaterChild]) == 1)
            {
                break;
            }

            Swap(current, greaterChild, arr);

            current = greaterChild;
        }
    }

    private static void Swap(int i1, int i2, T[] arr)
    {
        T old = arr[i1];
        arr[i1] = arr[i2];
        arr[i2] = old;
    }
}
