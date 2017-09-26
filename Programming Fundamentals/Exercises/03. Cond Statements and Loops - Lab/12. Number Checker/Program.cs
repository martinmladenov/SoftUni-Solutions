using System;

namespace _12._Number_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(int.TryParse(s, out int _) ? "It is a number." : "Invalid input!");
        }
    }
}
