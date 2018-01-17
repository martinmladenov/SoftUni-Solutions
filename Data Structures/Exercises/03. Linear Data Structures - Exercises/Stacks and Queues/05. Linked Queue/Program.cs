// ReSharper disable CheckNamespace

using System;

public class Program
{
    public static void Main()
    {
        LinkedQueue<int> queue = new LinkedQueue<int>();

        for (int i = 0; i < 100; i++)
        {
            queue.Enqueue(i);
        }

        Console.WriteLine(string.Join(" ", queue.ToArray()));

    }
}

