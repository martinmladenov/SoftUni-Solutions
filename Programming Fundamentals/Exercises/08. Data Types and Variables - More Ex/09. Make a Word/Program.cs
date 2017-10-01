using System;

namespace _09.Make_a_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = string.Empty;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
                word += char.Parse(Console.ReadLine());
            Console.WriteLine($"The word is: {word}");
        }
    }
}
