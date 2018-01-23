using System;
using System.Collections.Generic;
// ReSharper disable CheckNamespace

public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node _root;

    private class Node
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    private BinarySearchTree(Node root)
    {
        Copy(root);
    }

    public BinarySearchTree()
    {
    }

    private void Copy(Node node)
    {
        if (node == null)
            return;

        Insert(node.Value);
        Copy(node.Left);
        Copy(node.Right);
    }

    public void Insert(T value)
    {
        if (_root == null)
        {
            _root = new Node(value);
            return;
        }

        Node parent = null;
        Node current = _root;
        while (current != null)
        {
            parent = current;
            if (value.CompareTo(parent.Value) < 0)
            {
                current = current.Left;
            }
            else
            {
                current = current.Right;
            }
        }

        Node newNode = new Node(value);
        if (value.CompareTo(parent.Value) < 0)
        {
            parent.Left = newNode;
        }
        else
        {
            parent.Right = newNode;
        }
    }

    public bool Contains(T value)
    {
        var currNode = _root;
        while (currNode != null)
        {
            if (value.CompareTo(currNode.Value) < 0)
            {
                currNode = currNode.Left;
            }
            else if (value.CompareTo(currNode.Value) > 0)
            {
                currNode = currNode.Right;
            }
            else
            {
                break;
            }
        }

        return currNode != null;
    }

    public void DeleteMin()
    {
        if (_root == null)
            return;

        Node parent = null;
        Node min = _root;
        while (min.Left != null)
        {
            parent = min;
            min = min.Left;
        }

        if (parent == null)
        {
            _root = min.Right;
        }
        else
        {
            parent.Left = min.Right;
        }
    }

    public BinarySearchTree<T> Search(T item)
    {
        var currNode = _root;
        while (currNode != null)
        {
            if (item.CompareTo(currNode.Value) < 0)
            {
                currNode = currNode.Left;
            }
            else if (item.CompareTo(currNode.Value) > 0)
            {
                currNode = currNode.Right;
            }
            else
            {
                break;
            }
        }

        if (currNode == null)
            return null;

        return new BinarySearchTree<T>(currNode);
    }


    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();

        Range(_root, queue, startRange, endRange);

        return queue;
    }

    private void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        if (node == null)
            return;

        int nodeInLowerRange = startRange.CompareTo(node.Value);
        int nodeInHigherRange = endRange.CompareTo(node.Value);

        if (nodeInLowerRange <= 0)
            Range(node.Left, queue, startRange, endRange);

        if (nodeInLowerRange <= 0 && nodeInHigherRange >= 0)
            queue.Enqueue(node.Value);

        if (nodeInHigherRange >= 0)
            Range(node.Right, queue, startRange, endRange);
    }

    public void EachInOrder(Action<T> action)
    {
        EachInOrder(action, _root);
    }

    private void EachInOrder(Action<T> action, Node node)
    {
        if (node == null)
            return;

        EachInOrder(action, node.Left);
        action(node.Value);
        EachInOrder(action, node.Right);
    }
}

public class Launcher
{
    public static void Main()
    {
    }
}
