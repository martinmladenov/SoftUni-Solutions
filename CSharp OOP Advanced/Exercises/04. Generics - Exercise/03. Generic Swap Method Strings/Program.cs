using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Box<string>> boxes = new List<Box<string>>();

        for (int i = 0; i < n; i++)
        {
            Box<string> box = new Box<string>(Console.ReadLine());
            boxes.Add(box);
        }

        int[] toSwap = Console.ReadLine().Split().Select(int.Parse).ToArray();

        SwapBoxes(boxes, toSwap[0], toSwap[1]);

        boxes.ForEach(Console.WriteLine);
    }

    public static void SwapBoxes<T>(List<Box<T>> boxes, int i1, int i2)
    {
        Box<T> tmp = boxes[i1];
        boxes[i1] = boxes[i2];
        boxes[i2] = tmp;
    }
}
