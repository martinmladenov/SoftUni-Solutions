namespace _11.Poisonous_Plants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisonousPlants
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var days = new int[n];
            var stack = new Stack<int>();
            stack.Push(0);
            for (int i = 1; i < n; i++)
            {
                int maxDays = 0;
                while (stack.Count > 0 && plants[stack.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[stack.Pop()]);
                }

                if (stack.Count > 0)
                {
                    days[i] = maxDays + 1;
                }

                stack.Push(i);
            }

            Console.WriteLine(days.Max());
        }
    }
}
