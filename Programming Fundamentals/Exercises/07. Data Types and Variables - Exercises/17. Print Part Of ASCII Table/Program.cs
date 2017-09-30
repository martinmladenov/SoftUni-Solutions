using System;

namespace _17.Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = (char)int.Parse(Console.ReadLine());
            char end = (char)int.Parse(Console.ReadLine());
            for (char c = start; c <= end; c++)
                Console.Write(c + " ");
        }
    }
}
