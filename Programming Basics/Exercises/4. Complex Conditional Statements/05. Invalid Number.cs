using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            int num = int.Parse(Console.ReadLine());

            if((num < 100 || num > 200) && num != 0)
                Console.WriteLine("invalid");

        }
    }
}