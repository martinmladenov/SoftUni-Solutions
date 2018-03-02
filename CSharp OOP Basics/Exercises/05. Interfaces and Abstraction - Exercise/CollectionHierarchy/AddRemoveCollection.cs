using System.Collections.Generic;

public class AddRemoveCollection<T> : IAddRemoveCollection<T>
{
    private Queue<T> queue;

    public AddRemoveCollection()
    {
        queue = new Queue<T>(100);
    }

    public int Add(T element)
    {
        queue.Enqueue(element);
        return 0;
    }

    public T Remove()
    {
        return queue.Dequeue();
    }
}
