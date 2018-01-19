using System;

// ReSharper disable CheckNamespace
public class BinaryTree<T>
{
    public T Value { get; }
    public BinaryTree<T> LeftChild { get; set; }
    public BinaryTree<T> RightChild { get; set; }

    public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
    {
        Value = value;
        LeftChild = leftChild;
        RightChild = rightChild;
    }

    public void PrintIndentedPreOrder(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent * 2) + Value);

        LeftChild?.PrintIndentedPreOrder(indent + 1);
        RightChild?.PrintIndentedPreOrder(indent + 1);
    }

    public void EachInOrder(Action<T> action)
    {
        LeftChild?.EachInOrder(action);
        action(Value);
        RightChild?.EachInOrder(action);
    }

    public void EachPostOrder(Action<T> action)
    {
        LeftChild?.EachPostOrder(action);
        RightChild?.EachPostOrder(action);
        action(Value);
    }
}
