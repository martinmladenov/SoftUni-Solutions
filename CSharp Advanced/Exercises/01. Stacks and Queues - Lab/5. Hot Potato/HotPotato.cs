namespace _5.Hot_Potato
{
    using System;
    using System.Collections.Generic;

    public class HotPotato
    {
        public static void Main()
        {
            var children = new List<string>(Console.ReadLine().Split(' '));
            int n = int.Parse(Console.ReadLine());

            var removed = new Queue<string>();

            int i = 0;
            while (children.Count > 0)
            {
                i = (i + n - 1) % children.Count;
                removed.Enqueue(children[i]);
                children.RemoveAt(i);
            }

            while (removed.Count > 1)
            {
                Console.WriteLine($"Removed {removed.Dequeue()}");
            }

            Console.WriteLine($"Last is {removed.Dequeue()}");

        }
    }
}
