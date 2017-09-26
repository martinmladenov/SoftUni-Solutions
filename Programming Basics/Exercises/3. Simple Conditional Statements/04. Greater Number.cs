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
            Console.WriteLine("Enter two integers:");
            int i1 = int.Parse(Console.ReadLine());
            int i2 = int.Parse(Console.ReadLine());
            if (i1 > i2)
                Console.WriteLine("Greater number: "+i1);
            else
                Console.WriteLine("Greater number: " + i2);
        }
    }
}