using System;

namespace _11.String_Concatenation
{
    class Program
    {
        static void Main(string[] args)
        {
            char delimiter = char.Parse(Console.ReadLine());
            string evenOrOdd = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string final = string.Empty;
            for (int i = 1; i <= n; i++)
            {
                string line = Console.ReadLine();
                if (evenOrOdd == "odd" && i % 2 == 0 || evenOrOdd == "even" && i % 2 == 1)
                    continue;
                final += line + delimiter;
            }
            Console.WriteLine(final.Remove(final.Length - 1));
        }
    }
}
