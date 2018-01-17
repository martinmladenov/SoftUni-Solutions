namespace _01.Reverse_Numbers
{
    using System;
    using System.Collections.Generic;

    public class ReverseNumbers
    {
        public static void Main()
        {
            var stack = new Stack<string>(Console.ReadLine().Split());

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }
    }
}
