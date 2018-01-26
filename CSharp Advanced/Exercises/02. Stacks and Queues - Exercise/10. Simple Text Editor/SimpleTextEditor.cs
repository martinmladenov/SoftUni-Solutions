namespace _10.Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;

    public class SimpleTextEditor
    {
        public static void Main()
        {
            Stack<string> history = new Stack<string>();
            history.Push(string.Empty);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var split = Console.ReadLine().Split();
                int command = int.Parse(split[0]);

                if (command == 1)
                {
                    history.Push(history.Peek() + split[1]);
                }
                else if (command == 2)
                {
                    var oldLine = history.Peek();
                    history.Push(oldLine.Substring(0, oldLine.Length - int.Parse(split[1])));
                }
                else if (command == 3)
                {
                    Console.WriteLine(history.Peek()[int.Parse(split[1]) - 1]);
                }
                else if (command == 4 && history.Count > 1)
                {
                    history.Pop();
                }
            }
        }
    }
}
