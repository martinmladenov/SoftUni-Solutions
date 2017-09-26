using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int sum = 0;

            foreach(char c in input)
            {
                if (c == 'a') sum += 1;
                else if (c == 'e') sum += 2;
                else if (c == 'i') sum += 3;
                else if (c == 'o') sum += 4;
                else if (c == 'u') sum += 5;
            }

            Console.WriteLine(sum);
        }
    }
}