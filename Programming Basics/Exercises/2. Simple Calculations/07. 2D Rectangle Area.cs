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
			
			var x1 = double.Parse(Console.ReadLine());
			var y1 = double.Parse(Console.ReadLine());
			var x2 = double.Parse(Console.ReadLine());
			var y2 = double.Parse(Console.ReadLine());
			
			double s1 = Math.Abs(x1-x2);
			double s2 = Math.Abs(y1-y2);
			
			Console.WriteLine(s1*s2);
			Console.WriteLine(2*(s1+s2));
			
        }
    }
}
