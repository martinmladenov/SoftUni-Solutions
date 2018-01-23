namespace _4.Matching_Brackets
{
    using System;
    using System.Collections.Generic;

    public class MatchingBrackets
    {
        public static void Main()
        {
            var exp = Console.ReadLine();

            var indexes = new Stack<int>();
            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (exp[i] == ')')
                {
                    int index = indexes.Pop();
                    Console.WriteLine(exp.Substring(index, i - index + 1));
                }
            }
        }
    }
}
