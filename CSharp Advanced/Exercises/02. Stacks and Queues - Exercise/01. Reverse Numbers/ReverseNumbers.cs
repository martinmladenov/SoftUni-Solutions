namespace _01.Reverse_Numbers
{
    using System;
    using System.Collections.Generic;

    public class ReverseNumbers
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Trim().Split();

            Stack<int> stack = new Stack<int>();

            foreach (var str in arr)
            {
                stack.Push(int.Parse(str));
            }

            var reversed = new int[stack.Count];

            for (int i = 0; i < reversed.Length; i++)
            {
                reversed[i] = stack.Pop();
            }

            Console.WriteLine(string.Join(" ", reversed));
        }
    }
}
