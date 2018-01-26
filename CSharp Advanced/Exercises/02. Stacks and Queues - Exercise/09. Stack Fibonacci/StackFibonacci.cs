namespace _09.Stack_Fibonacci
{
    using System;
    using System.Collections.Generic;

    public class StackFibonacci
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);
            for (int i = 0; i < n - 1; i++)
            {
                long prev = stack.Pop();
                long prev2 = stack.Pop();
                stack.Push(prev);
                stack.Push(prev + prev2);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
