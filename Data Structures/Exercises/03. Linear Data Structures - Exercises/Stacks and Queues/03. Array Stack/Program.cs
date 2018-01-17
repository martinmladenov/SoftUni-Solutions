// ReSharper disable CheckNamespace
using System;

public class Program
{
    public static void Main()
    {
        ArrayStack<int> stack = new ArrayStack<int>();

        stack.Push(2);
        stack.Push(3);
        stack.Push(4);

        Console.WriteLine(string.Join(" ", stack.ToArray()));
        Console.WriteLine(stack.Pop());
    }
}