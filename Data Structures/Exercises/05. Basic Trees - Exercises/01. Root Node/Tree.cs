using System.Collections.Generic;

public class Tree<T>
{
    public T Value { get; set; }
    public Tree<T> Parent { get; set; }
    public List<Tree<T>> Children { get; private set; }

    public Tree(T value, params Tree<T>[] children)
    {
        Value = value;
        Children = new List<Tree<T>>();
        foreach (var child in children)
        {
            Children.Add(child);
            child.Parent = this;
        }
    }
}