using System;
using System.Collections.Generic;

public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
{
    private Node _root;

    private Node FindElement(T element)
    {
        Node current = _root;

        while (current != null)
        {
            if (current.Value.CompareTo(element) > 0)
            {
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return current;
    }

    private void PreOrderCopy(Node node)
    {
        if (node == null)
        {
            return;
        }

        Insert(node.Value);
        PreOrderCopy(node.Left);
        PreOrderCopy(node.Right);
    }

    private Node Insert(T element, Node node)
    {
        if (node == null)
        {
            node = new Node(element);
        }
        else if (element.CompareTo(node.Value) < 0)
        {
            node.Left = Insert(element, node.Left);
        }
        else if (element.CompareTo(node.Value) > 0)
        {
            node.Right = Insert(element, node.Right);
        }

        return node;
    }

    private void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        int nodeInLowerRange = startRange.CompareTo(node.Value);
        int nodeInHigherRange = endRange.CompareTo(node.Value);

        if (nodeInLowerRange < 0)
        {
            Range(node.Left, queue, startRange, endRange);
        }
        if (nodeInLowerRange <= 0 && nodeInHigherRange >= 0)
        {
            queue.Enqueue(node.Value);
        }
        if (nodeInHigherRange > 0)
        {
            Range(node.Right, queue, startRange, endRange);
        }
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        EachInOrder(node.Left, action);
        action(node.Value);
        EachInOrder(node.Right, action);
    }

    private BinarySearchTree(Node node)
    {
        PreOrderCopy(node);
    }

    public BinarySearchTree()
    {
    }

    public void Insert(T element)
    {
        _root = Insert(element, _root);
    }

    public bool Contains(T element)
    {
        Node current = FindElement(element);

        return current != null;
    }

    public void EachInOrder(Action<T> action)
    {
        EachInOrder(_root, action);
    }

    public BinarySearchTree<T> Search(T element)
    {
        Node current = FindElement(element);

        return new BinarySearchTree<T>(current);
    }

    public void DeleteMin()
    {
        if (_root == null)
        {
            throw new InvalidOperationException();
        }

        Node current = _root;
        Node parent = null;
        while (current.Left != null)
        {
            parent = current;
            current = current.Left;
        }

        if (parent == null)
        {
            _root = _root.Right;
        }
        else
        {
            parent.Left = current.Right;
        }
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();

        Range(_root, queue, startRange, endRange);

        return queue;
    }

    public void Delete(T element)
    {
        if (Count(_root) == 0 || !Contains(element))
        {
            throw new InvalidOperationException();
        }
        _root = Delete(_root, element);
    }

    private Node Delete(Node node, T element)
    {

        if (node == null)
        {
            return null;
        }

        int compare = node.Value.CompareTo(element);

        if (compare > 0)
        {
            node.Left = Delete(node.Left, element);
        }
        else if (compare < 0)
        {
            node.Right = Delete(node.Right, element);
        }
        else
        {

            if (node.Left == null) return node.Right;
            if (node.Right == null) return node.Left;

            Node leftMost = node.Right;

            while (leftMost.Left != null)
            {
                leftMost = leftMost.Left;
            }


            node.Value = leftMost.Value;

            node.Right = Delete(node.Right, leftMost.Value);
        }
        
        return node;
    }
    public void DeleteMax()
    {
        if (_root == null)
        {
            throw new InvalidOperationException();
        }

        Node currentNode = _root;
        Node parent = null;

        while (currentNode.Right != null)
        {
            parent = currentNode;
            currentNode = currentNode.Right;
        }

        if (parent == null)
        {
            _root = _root.Left;
        }
        else
        {
            parent.Right = currentNode.Left;
        }
    }

    public int Count()
    {
        return Count(_root);
    }

    private int Count(Node n)
    {
        if (n == null)
            return 0;

        return 1 + Count(n.Left) + Count(n.Right);
    }

    public int Rank(T element)
    {
        return Rank(element, _root);
    }

    private int Rank(T element, Node node)
    {
        if (node == null)
        {
            return 0;
        }

        int compare = element.CompareTo(node.Value);

        if (compare < 0)
        {
            return Rank(element, node.Left);
        }

        if (compare > 0)
        {
            return 1 + Count(node.Left) + Rank(element, node.Right);
        }

        return Count(node.Left);
    }

    public T Select(int rank)
    {

        Node node = Select(rank, _root);

        if (node == null)
        {
            throw new InvalidOperationException();
        }

        return node.Value;
    }

    private Node Select(int rank, Node node)
    {

        if (node == null)
        {
            return null;
        }

        int leftCount = Count(node.Left);

        if (leftCount.CompareTo(rank) > 0)
        {
            return Select(rank, node.Left);
        }

        if (leftCount.CompareTo(rank) < 0)
        {
            return Select(rank - leftCount - 1, node.Right);
        }

        return node;
    }

    public T Ceiling(T element)
    {
        return Select(Rank(element) + 1);

    }

    public T Floor(T element)
    {
        return Select(Rank(element) - 1);

    }

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
}

public class Launcher
{
    public static void Main(string[] args)
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);
        bst.Insert(6);

        // Act
        bst.Delete(5);
        List<int> nodes = new List<int>();
        bst.EachInOrder(nodes.Add);

        // Assert
        int[] expectedNodes = new int[] { 1, 3, 4, 6, 8, 9, 10, 37, 39, 45 };

        Console.WriteLine(string.Join(" ", nodes));
        Console.WriteLine(string.Join(" ", expectedNodes));



    }
}