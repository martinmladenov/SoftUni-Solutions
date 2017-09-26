using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = int.Parse(Console.ReadLine());

            if (i < 100)
                Console.WriteLine("Less than 100");
            else if (i > 200)
                Console.WriteLine("Greater than 200");
            else
                Console.WriteLine("Between 100 and 200");

        }
    }
}