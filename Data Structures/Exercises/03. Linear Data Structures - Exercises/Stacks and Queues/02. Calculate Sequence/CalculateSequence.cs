namespace _02.Calculate_Sequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CalculateSequence
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var queue = new Queue<int>(new[] { n });

            for (int i = 0, skip = 0, curr = n; i < 49; i++)
            {
                int s = 0;
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

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
