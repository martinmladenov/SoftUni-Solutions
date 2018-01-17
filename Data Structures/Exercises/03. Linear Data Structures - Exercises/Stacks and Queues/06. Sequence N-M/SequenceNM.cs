namespace _06.Sequence_N_M
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SequenceNM
    {
        public static void Main()
        {
            var split = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

            int n = split[0], m = split[1];

            var queue = new Queue<Item>();
            queue.Enqueue(new Item(n));

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                if (item.Value < m)
                {
                    queue.Enqueue(new Item(item.Value + 1, item));
                    queue.Enqueue(new Item(item.Value + 2, item));
                    queue.Enqueue(new Item(item.Value * 2, item));
                }
                else if (item.Value == m)
                {
                    var list = new LinkedList<int>();
                    while (item != null)
                    {
                        list.AddFirst(item.Value);
                        item = item.Previous;
                    }

                    Console.WriteLine(string.Join(" -> ", list));

                    break;
                }
            }
        }

        private class Item
        {
            public int Value { get; }
            public Item Previous { get; }

            public Item(int value, Item previous = null)
            {
                Value = value;
                Previous = previous;
            }
        }
    }
}
