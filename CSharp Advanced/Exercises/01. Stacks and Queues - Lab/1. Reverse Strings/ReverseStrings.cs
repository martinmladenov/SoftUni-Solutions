namespace _1.Reverse_Strings
{
    using System;
    using System.Collections.Generic;

    public class ReverseStrings
    {
        public static void Main()
        {
            var str = Console.ReadLine();
            var stack = new Stack<char>(str);

            while (stack.Count>0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
