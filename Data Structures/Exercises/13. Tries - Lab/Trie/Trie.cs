using System;
using System.Collections.Generic;
// ReSharper disable CheckNamespace

public class Trie<T>
{
    private Node root;

    private class Node
    {
        public T Val;
        public bool IsTerminal;
        public Dictionary<char, Node> Next = new Dictionary<char, Node>();
    }

    public T GetValue(string key)
    {
        var x = GetNode(root, key, 0);
        if (x == null || !x.IsTerminal)
        {
            throw new InvalidOperationException();
        }

        return x.Val;
    }

    public bool Contains(string key)
    {
        var node = GetNode(this.root, key, 0);
        return node != null && node.IsTerminal;
    }

    public void Insert(string key, T val)
    {
        root = Insert(root, key, val, 0);
    }

    public IEnumerable<string> GetByPrefix(string prefix)
    {
        var results = new Queue<string>();
        var x = GetNode(root, prefix, 0);

        this.Collect(x, prefix, results);

        return results;
    }

    private Node GetNode(Node x, string key, int d)
    {
        if (x == null)
        {
            return null;
        }

        if (d == key.Length)
        {
            return x;
        }

        Node node = null;
        char c = key[d];

        if (x.Next.ContainsKey(c))
        {
            node = x.Next[c];
        }

        return GetNode(node, key, d + 1);
    }

    private Node Insert(Node x, string key, T val, int d)
    {
        if (x == null)
        {
            x = new Node();
        }

        if (d == key.Length)
        {
            x.IsTerminal = true;
            x.Val = val;
            return x;
        }

        Node current = null;

        char currentChar = key[d];
        if (x.Next.ContainsKey(currentChar))
        {
            current = x.Next[currentChar];
        }

        x.Next[currentChar] = Insert(current, key, val, d + 1);
        return x;
    }

    private void Collect(Node x, string prefix, Queue<string> results)
    {
        if (x == null)
        {
            return;
        }

        if (x.Val != null && x.IsTerminal)
        {
            results.Enqueue(prefix);
        }

        foreach (var c in x.Next.Keys)
        {
            Collect(x.Next[c], prefix + c, results);
        }
    }
}