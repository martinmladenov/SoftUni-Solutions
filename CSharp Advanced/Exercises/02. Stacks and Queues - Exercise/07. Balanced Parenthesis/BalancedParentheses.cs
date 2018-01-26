namespace _07.Balanced_Parenthesis
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BalancedParentheses
    {
        public static void Main()
        {
            var line = Console.ReadLine();

            var parentheses = new Stack<char>();

            bool balanced = true;

            foreach (var c in line)
            {
                if (c == '{' || c == '[' || c == '(')
                {
                    parentheses.Push(c);
                    continue;
                }

                if (parentheses.Count == 0 ||
                    c == '}' && parentheses.Pop() != '{' ||
                    c == ']' && parentheses.Pop() != '[' ||
                    c == ')' && parentheses.Pop() != '(')
                {
                    balanced = false;
                    break;
                }
            }

            Console.WriteLine(balanced ? "YES" : "NO");
        }

    }
}
