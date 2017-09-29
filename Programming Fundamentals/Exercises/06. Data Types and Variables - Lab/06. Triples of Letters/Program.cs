using System;

namespace _06.Triples_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            char n = (char)('a' - 1 + int.Parse(Console.ReadLine()));
            for (char c1 = 'a'; c1 <= n; c1++)
                for (char c2 = 'a'; c2 <= n; c2++)
                    for (char c3 = 'a'; c3 <= n; c3++)
                        Console.WriteLine($"{c1}{c2}{c3}");
        }
    }
}
