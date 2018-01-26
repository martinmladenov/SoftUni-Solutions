namespace _03.Maximum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumElement
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            var maxElements = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int type = line[0];

                if (type == 1)
                {
                    int s = line[1];
                    stack.Push(s);

                    if (maxElements.Count == 0 || s > maxElements.Peek())
                    {
                        maxElements.Push(s);
                    }
                }
                else if (type == 2)
                {
                    if (stack.Peek() == maxElements.Peek())
                    {
                        maxElements.Pop();
                    }

                    stack.Pop();
                }
                else if (type == 3)
                {
                    Console.WriteLine(maxElements.Peek());
                }
            }
        }
    }
}
