namespace LinkedListTraversal
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            for (int i = 0; i < n; i++)
            {
                string[] split = Console.ReadLine().Split();
                string command = split[0];
                int number = int.Parse(split[1]);

                switch (command)
                {
                    case "Add":
                        list.Add(number);
                        break;
                    case "Remove":
                        list.Remove(number);
                        break;
                }
            }

            Console.WriteLine(list.Count);
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
