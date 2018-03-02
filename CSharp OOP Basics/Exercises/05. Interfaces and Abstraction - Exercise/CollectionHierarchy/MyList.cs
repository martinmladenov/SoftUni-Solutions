using System.Collections.Generic;

public class MyList<T> : IAddRemoveCollection<T>, ICountable
{
    private Stack<T> stack;

    public MyList()
    {
        stack = new Stack<T>(100);
    }

    public int Used => stack.Count;

    public int Add(T element)
    {
        stack.Push(element);
        return 0;
    }

    public T Remove()
    {
        return stack.Pop();
    }
}
