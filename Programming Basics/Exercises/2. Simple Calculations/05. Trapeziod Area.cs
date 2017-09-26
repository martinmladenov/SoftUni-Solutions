using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
			
			var b1 = double.Parse(Console.ReadLine());
			var b2 = double.Parse(Console.ReadLine());
			var h = double.Parse(Console.ReadLine());
			Console.WriteLine("Trapezoid area = "+((b2+b1) * h / 2));
			
        }
    }
}