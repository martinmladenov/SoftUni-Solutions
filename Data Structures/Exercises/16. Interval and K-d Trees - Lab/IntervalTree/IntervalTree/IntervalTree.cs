using System;
using System.Collections.Generic;

public class IntervalTree
{
    private class Node
    {
        internal Interval interval;
        internal double max;
        internal Node right;
        internal Node left;

        public Node(Interval interval)
        {
            this.interval = interval;
            this.max = interval.Hi;
        }
    }

    private Node root;

    public void Insert(double lo, double hi)
    {
        this.root = this.Insert(this.root, lo, hi);
    }

    public void EachInOrder(Action<Interval> action)
    {
        EachInOrder(this.root, action);
    }

    public Interval SearchAny(double lo, double hi)
    {
        var x = this.root;
        while (x != null && !x.interval.Intersects(lo, hi))
        {
            if (x.left != null && x.left.max > lo)
            {
                x = x.left;
            }
            else
            {
                x = x.right;
            }
        }

        return x?.interval;
    }

    public IEnumerable<Interval> SearchAll(double lo, double hi)
    {
        List<Interval> list = new List<Interval>();

        if (this.root == null)
        {
            return list;
        }

        SearchAll(this.root, list, lo, hi);

        return list;
    }

    private void SearchAll(Node node, List<Interval> list, double lo, double hi)
    {
        if (node.left != null && node.left.max > lo)
        {
            SearchAll(node.left, list, lo, hi);
        }

        if (node.interval.Intersects(lo, hi))
        {
            list.Add(node.interval);
        }

        if (node.right != null && node.right.interval.Lo < hi)
        {
            SearchAll(node.right, list, lo, hi);
        }
    }

    private void EachInOrder(Node node, Action<Interval> action)
    {
        if (node == null)
        {
            return;
        }

        EachInOrder(node.left, action);
        action(node.interval);
        EachInOrder(node.right, action);
    }

    private Node Insert(Node node, double lo, double hi)
    {
        if (node == null)
        {
            return new Node(new Interval(lo, hi));
        }

        int cmp = lo.CompareTo(node.interval.Lo);
        if (cmp < 0)
        {
            node.left = Insert(node.left, lo, hi);
        }
        else if (cmp > 0)
        {
            node.right = Insert(node.right, lo, hi);
        }

        UpdateMax(node);

        return node;
    }

    private void UpdateMax(Node node)
    {
        var maxChild = GetMax(node.left, node.right);
        node.max = GetMax(node, maxChild).max;
    }

    private Node GetMax(Node a, Node b)
    {
        if (a == null)
        {
            return b;
        }

        if (b == null)
        {
            return a;
        }

        return a.max > b.max ? a : b;
    }


}
