using System;

public class ArrayCreator
{
    public static T[] Create<T>(int length, T item)
    {
        T[] arr = new T[length];
        Array.Fill(arr, item);
        return arr;
    }
}
