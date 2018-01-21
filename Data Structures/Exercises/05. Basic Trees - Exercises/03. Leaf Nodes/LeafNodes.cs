using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable CheckNamespace
public class LeafNodes
{
    private static Dictionary<int, Tree<int>> _nodeByValue = new Dictionary<int, Tree<int>>();

    public static void Main()
    {
        ReadTree();
        Console.WriteLine("Leaf nodes: {0}",
            string.Join(" ", GetLeafNodes()
                .Select(t => t.Value)
                .OrderBy(t => t)));
    }

    private static Tree<int> GetTreeNodeByValue(int value)
    {
        if (!_nodeByValue.ContainsKey(value))
        {
            _nodeByValue[value] = new Tree<int>(value);
        }

        return _nodeByValue[value];
    }

    public static void AddEdge(int parent, int child)
    {
        var parentNode = GetTreeNodeByValue(parent);
        var childNode = GetTreeNodeByValue(child);

        parentNode.Children.Add(childNode);
        childNode.Parent = parentNode;
    }

    private static void ReadTree()
    {
        int nodeCount = int.Parse(Console.ReadLine());
        for (int i = 1; i < nodeCount; i++)
        {
            var edge = Console.ReadLine().Split(' ');
            AddEdge(int.Parse(edge[0]), int.Parse(edge[1]));
        }
    }

    private static Tree<int> GetRootNode()
    {
        return _nodeByValue.Values.FirstOrDefault(x => x.Parent == null);
    }

    private static Tree<int>[] GetLeafNodes()
    {
        return _nodeByValue.Values
            .Where(t => t.Children.Count == 0)
            .ToArray();
    }
}