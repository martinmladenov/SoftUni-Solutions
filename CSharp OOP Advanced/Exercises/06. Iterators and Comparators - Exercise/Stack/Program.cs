namespace Stack
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var stack = new Stack<int>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] split = input.Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (split[0])
                    {
                        case "Push":
                            foreach (var i in split.Skip(1).Select(int.Parse))
                            {
                                stack.Push(i);
                            }
                            break;
                        case "Pop":
                            stack.Pop();
                            break;
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var j in stack)
                {
                    Console.WriteLine(j);
                }
            }
        }
    }
}
