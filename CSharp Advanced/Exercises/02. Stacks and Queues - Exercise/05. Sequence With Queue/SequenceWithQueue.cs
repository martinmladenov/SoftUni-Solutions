namespace _05.Sequence_With_Queue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SequenceWithQueue
    {
        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            var queue = new Queue<long>(new[] { n });

            long curr = n;
            for (int i = 0, skip = 0; i < 49; i++)
            {
                long s = 0;
                switch (i % 3)
                {
                    case 0:
                        curr = queue.Skip(skip++).Take(1).ElementAt(0);
                        s = curr + 1;
                        break;
                    case 1:
                        s = 2 * curr + 1;
                        break;
                    case 2:
                        s = curr + 2;
                        break;
                }
                queue.Enqueue(s);
            }

            Console.WriteLine(string.Join(" ", queue));
        }
    }
}
