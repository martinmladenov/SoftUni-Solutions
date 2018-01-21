using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable CheckNamespace
public class DeepestNode
{
    private static Dictionary<int, Tree<int>> _nodeByValue = new Dictionary<int, Tree<int>>();


    public static void Main()
    {
        ReadTree();
        Console.WriteLine("Deepest node: {0}",
            GetDeepestNode().Value);
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

    private static Tree<int> GetDeepestNode()
    {
        int biggestDepth = 0;
        Tree<int> deepestNode = null;
        FindDeepestNode(GetRootNode(), 0, ref biggestDepth, ref deepestNode);
        return deepestNode;
    }

    private static void FindDeepestNode(Tree<int> currentNode, int currentDepth, ref int biggestDepth, ref Tree<int> deepestNode)
    {
        if (biggestDepth < currentDepth)
        {
            biggestDepth = currentDepth;
            deepestNode = currentNode;
        }

        foreach (var child in currentNode.Children)
        {
            FindDeepestNode(child, currentDepth + 1, ref biggestDepth, ref deepestNode);
        }
    }
}