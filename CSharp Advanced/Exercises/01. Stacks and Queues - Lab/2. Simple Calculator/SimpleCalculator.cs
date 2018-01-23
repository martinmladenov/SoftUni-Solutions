namespace _2.Simple_Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleCalculator
    {
        public static void Main()
        {
            var str = Console.ReadLine();
            var stack = new Stack<string>(str.Split(' ').Reverse());
            while (stack.Count > 1)
            {
                int a = int.Parse(stack.Pop());
                char op = stack.Pop()[0];
                int b = int.Parse(stack.Pop());

                int result = 0;
                if (op == '+')
                    result = a + b;
                else if (op == '-')
                    result = a - b;

                stack.Push(result.ToString());
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
