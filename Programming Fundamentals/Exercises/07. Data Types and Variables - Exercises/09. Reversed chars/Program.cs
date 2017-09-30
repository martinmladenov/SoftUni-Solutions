using System;

namespace _09.Reversed_chars
{
    class Program
    {
        static void Main(string[] args)
        {
            char c1 = char.Parse(Console.ReadLine());
            char c2 = char.Parse(Console.ReadLine());
            char c3 = char.Parse(Console.ReadLine());

            Console.WriteLine($"{c3}{c2}{c1}");

        }
    }
}
