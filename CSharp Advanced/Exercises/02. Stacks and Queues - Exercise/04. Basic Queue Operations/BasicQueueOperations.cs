namespace _04.Basic_Queue_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicQueueOperations
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

            var queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(elements[i]);
            }

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }


            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (queue.Contains(x))
            {
                Console.WriteLine("true");
                return;
            }

            int minElement = queue.Dequeue();

            while (queue.Count > 0)
            {
                int c = queue.Dequeue();
                if (minElement > c)
                    minElement = c;
            }

            Console.WriteLine(minElement);
        }
    }
}
