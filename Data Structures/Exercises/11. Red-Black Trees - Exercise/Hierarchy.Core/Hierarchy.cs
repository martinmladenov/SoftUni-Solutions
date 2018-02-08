using System;
using System.Collections.Generic;
using System.Collections;

// ReSharper disable CheckNamespace

public class Hierarchy<T> : IHierarchy<T>
{

    private Dictionary<T, Node> nodesByValue;

    private Node root;

    public Hierarchy(T root)
    {
        this.root = new Node(root, null);
        nodesByValue = new Dictionary<T, Node>
        {
            {root, this.root}
        };
    }

    public int Count => nodesByValue.Count;

    public void Add(T element, T child)
    {
        if (!nodesByValue.ContainsKey(element) || nodesByValue.ContainsKey(child))
        {
            throw new ArgumentException();
        }

        Node parentNode = nodesByValue[element];
        Node childNode = new Node(child, parentNode);
        parentNode.Children.Add(childNode);
        nodesByValue.Add(child, childNode);
    }

    public void Remove(T element)
    {
        if (!nodesByValue.ContainsKey(element))
        {
            throw new ArgumentException();
        }

        Node nodeToRemove = nodesByValue[element];

        if (nodeToRemove == root)
        {
            throw new InvalidOperationException();
        }

        foreach (var child in nodeToRemove.Children)
        {
            child.Parent = nodeToRemove.Parent;
        }

        nodeToRemove.Parent.Children.AddRange(nodeToRemove.Children);
        nodeToRemove.Parent.Children.Remove(nodeToRemove);
        nodesByValue.Remove(element);
    }

    public IEnumerable<T> GetChildren(T item)
    {
        if (!nodesByValue.ContainsKey(item))
        {
            throw new ArgumentException();
        }

        List<Node> childNodes = nodesByValue[item].Children;

        T[] children = new T[childNodes.Count];

        for (int i = 0; i < childNodes.Count; i++)
        {
            children[i] = childNodes[i].Value;
        }

        return children;
    }

    public T GetParent(T item)
    {
        if (!nodesByValue.ContainsKey(item))
        {
            throw new ArgumentException();
        }

        Node node = nodesByValue[item];
        if (node.Parent == null)
        {
            return default(T);
        }

        return node.Parent.Value;
    }

    public bool Contains(T value)
    {
        return nodesByValue.ContainsKey(value);
    }

    public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
    {
        Hierarchy<T> smaller;
        Hierarchy<T> larger;

        if (other.Count > this.Count)
        {
            larger = other;
            smaller = this;
        }
        else
        {
            larger = this;
            smaller = other;
        }

        LinkedList<T> common = new LinkedList<T>();

        foreach (var element in smaller)
        {
            if (larger.Contains(element))
            {
                common.AddFirst(element);
            }
        }

        return common;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Queue<Node> bfsQueue = new Queue<Node>();
        bfsQueue.Enqueue(root);

        while (bfsQueue.Count > 0)
        {
            Node curr = bfsQueue.Dequeue();

            foreach (var child in curr.Children)
            {
                bfsQueue.Enqueue(child);
            }
            yield return curr.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    class Node
    {
        public T Value { get; set; }
        public List<Node> Children { get; set; }
        public Node Parent { get; set; }

        public Node(T value, Node parent)
        {
            Value = value;
            Children = new List<Node>();
            Parent = parent;
        }
    }
}
