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
            double input = double.Parse(Console.ReadLine());
            if(input >= 5.5)
                Console.WriteLine("Excellent!");
            else
                Console.WriteLine("Not excellent.");
        }
    }
}