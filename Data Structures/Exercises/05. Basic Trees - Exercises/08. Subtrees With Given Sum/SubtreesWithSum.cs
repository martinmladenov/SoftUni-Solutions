using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable CheckNamespace
public class SubtreesWithSum
{
    private static Dictionary<int, Tree<int>> _nodeByValue = new Dictionary<int, Tree<int>>();


    public static void Main()
    {
        ReadTree();
        int desiredSum = int.Parse(Console.ReadLine());
        Console.WriteLine($"Subtrees of sum {desiredSum}:");
        PrintSubtreesWithSum(desiredSum, GetRootNode());
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

    private static int PrintSubtreesWithSum(int desiredSum, Tree<int> currentNode)
    {

        int currentSum = currentNode.Value;

        foreach (Tree<int> child in currentNode.Children)
        {
            currentSum += PrintSubtreesWithSum(desiredSum, child);
        }

        if (currentSum == desiredSum)
        {
            var list = new List<int>();
            AddTreeDFS(currentNode, list);
            Console.WriteLine(string.Join(" ", list));
        }

        return currentSum;
    }

    private static void AddTreeDFS(Tree<int> node, List<int> list)
    {
        list.Add(node.Value);

        foreach (Tree<int> child in node.Children)
        {
            AddTreeDFS(child, list);
        }
    }
}