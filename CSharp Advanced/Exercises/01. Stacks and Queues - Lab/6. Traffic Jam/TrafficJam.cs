namespace _6.Traffic_Jam
{
    using System;
    using System.Collections.Generic;

    public class TrafficJam
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var carQueue = new Queue<string>();
            int passed = 0;

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < n && carQueue.Count > 0; i++)
                    {
                        Console.WriteLine($"{carQueue.Dequeue()} passed!");
                        passed++;
                    }
                    continue;
                }

                carQueue.Enqueue(input);
            }

            Console.WriteLine($"{passed} cars passed the crossroads.");
        }
    }
}
