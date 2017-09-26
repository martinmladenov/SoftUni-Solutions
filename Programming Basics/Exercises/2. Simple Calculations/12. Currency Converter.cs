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
			double input = double.Parse(Console.ReadLine());
			string fr = Console.ReadLine();
			string to = Console.ReadLine();
			
			double frKurs;
			if(fr == "BGN") frKurs = 1;
			else if(fr == "USD") frKurs = 1.79549;
			else if(fr == "EUR") frKurs = 1.95583;
			else frKurs = 2.53405;
			
			double bgn = input * frKurs;
			
			double toKurs;
			if(to == "BGN") toKurs = 1;
			else if(to == "USD") toKurs = 1.79549;
			else if(to == "EUR") toKurs = 1.95583;
			else toKurs = 2.53405;
			
			double output = bgn / toKurs;
			
			
			Console.WriteLine(Math.Round(output,2)+" "+to);					
        }
    }
}
