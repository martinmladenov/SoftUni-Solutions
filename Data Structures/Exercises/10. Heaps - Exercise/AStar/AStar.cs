using System;
using System.Collections.Generic;
// ReSharper disable CheckNamespace

public class AStar
{

    private char[,] map;

    public AStar(char[,] map)
    {
        Node start = null;
        Node goal = null;

        for (int row = 0; row < map.GetLength(0); row++)
        {
            for (int col = 0; col < map.GetLength(1); col++)
            {
                if (map[row, col] == 'P')
                {
                    start = new Node(row, col);
                }
                else if (map[row, col] == '*')
                {
                    goal = new Node(row, col);
                }
            }
        }

        this.map = map;

        Console.WriteLine($"{{ {string.Join(", ", GetPath(start, goal))} }}");
    }

    public static int GetH(Node current, Node goal)
    {
        var deltaX = Math.Abs(current.Col - goal.Col);
        var deltaY = Math.Abs(current.Row - goal.Row);

        return deltaX + deltaY;
    }

    public IEnumerable<Node> GetPath(Node start, Node goal)
    {
        bool IsFree(int row, int col)
        {
            return row >= 0 && row < map.GetLength(0) &&
                   col >= 0 && col < map.GetLength(1) &&
                   (map[row, col] == '-' || map[row, col] == '*');
        }

        PriorityQueue<Node> open = new PriorityQueue<Node>();
        open.Enqueue(start);

        Dictionary<Node, Node> parent = new Dictionary<Node, Node>();
        Dictionary<Node, int> cost = new Dictionary<Node, int>();
        parent[start] = null;
        cost[start] = 0;

        while (open.Count > 0)
        {
            Node current = open.Dequeue();
            if (goal.Equals(current))
            {
                break;
            }

            void ExecNeighbor(int row, int col)
            {
                if (row == 0 && col == 3)
                {
                    Console.WriteLine(row + " " + col);
                }
                if (!IsFree(row, col))
                {
                    return;
                }

                Node neighbor = new Node(row, col);
                int newCost = cost[current] + 1;
                if (cost.ContainsKey(neighbor) && newCost >= cost[neighbor])
                {
                    return;
                }

                cost[neighbor] = newCost;
                neighbor.F = newCost + GetH(neighbor, goal);
                open.Enqueue(neighbor);
                parent[neighbor] = current;
            }

            ExecNeighbor(current.Row - 1, current.Col);
            ExecNeighbor(current.Row + 1, current.Col);
            ExecNeighbor(current.Row, current.Col - 1);
            ExecNeighbor(current.Row, current.Col + 1);
        }

        if (!parent.ContainsKey(goal))
            return new Node[1] { start };

        Stack<Node> path = new Stack<Node>();

        Node currNode = goal;

        while (currNode != null)
        {
            path.Push(currNode);
            currNode = parent[currNode];
        }

        return path;
    }
}

