using System;

public static class Sorter
{
    public static void Sort<T>(CustomList<T> list)
        where T : IComparable<T>
    {
        list.Sort();
    }
}
