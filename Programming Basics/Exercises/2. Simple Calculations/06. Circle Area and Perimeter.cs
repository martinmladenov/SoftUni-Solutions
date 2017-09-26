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
			
			var r = double.Parse(Console.ReadLine());
			Console.WriteLine("Area = "+Math.PI*r*r);
			Console.WriteLine("Perimeter = "+Math.PI*2*r);
			
        }
    }
}
