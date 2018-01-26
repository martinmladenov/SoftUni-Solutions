namespace _02.Basic_Stack_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperations
    {
        public static void Main()
        {
            var split = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = split[0];
            int s = split[1];
            int x = split[2];

            var elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                stack.Push(elements[i]);
            }

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }


            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
                return;
            }

            int minElement = stack.Pop();

            while (stack.Count > 0)
            {
                int c = stack.Pop();
                if (minElement > c)
                    minElement = c;
            }

            Console.WriteLine(minElement);
        }
    }
}
