using System;

namespace _08.SMS_Typing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (input == "0")
                {
                    Console.Write(" ");
                    continue;
                }
                int index = (input[0] - '0' - 2) * 3 + input.Length - 1 + (input[0] > '7' ? 1 : 0);
                Console.Write((char)('a' + index));
            }
        }
    }
}
