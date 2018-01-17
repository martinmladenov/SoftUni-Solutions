using System;

// ReSharper disable CheckNamespace
public class Program
{
    public static void Main()
    {
        var stack = new LinkedStack<int>();
        stack.Push(5);
        Console.WriteLine(stack.Pop());
    }
}

