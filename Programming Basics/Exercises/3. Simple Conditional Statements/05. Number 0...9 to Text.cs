using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            if (input == 0)
                Console.WriteLine("zero");
            else if (input == 1)
                Console.WriteLine("one");
            else if (input == 2)
                Console.WriteLine("two");
            else if(input == 3)
                Console.WriteLine("three");
            else if (input == 4)
                Console.WriteLine("four");
            else if (input == 5)
                Console.WriteLine("five");
            else if (input == 6)
                Console.WriteLine("six");
            else if (input == 7)
                Console.WriteLine("seven");
            else if (input == 8)
                Console.WriteLine("eight");
            else if (input == 9)
                Console.WriteLine("nine");
            else
                Console.WriteLine("number too big");
        }
    }
}
