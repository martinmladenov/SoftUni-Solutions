// ReSharper disable once CheckNamespace

using System;

class Program
{
    public static void Main()
    {
        ReversedList<int> reversedList = new ReversedList<int>();

        reversedList.Add(5);
        reversedList.Add(6);
        reversedList.Add(7);
        reversedList.Add(8);

        foreach (var item in reversedList)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
        Console.WriteLine(reversedList[0]);
    }
}