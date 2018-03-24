using System;
using System.Collections.Generic;

public class Box<T>
{
    private Stack<T> stack;

    public Box()
    {
        stack = new Stack<T>();
    }

    public int Count => stack.Count;

    public void Add(T element)
    {
        stack.Push(element);
    }

    public T Remove()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }

        return stack.Pop();
    }
}
