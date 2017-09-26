using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Final_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            int dancers = int.Parse(Console.ReadLine());
            double points = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string location = Console.ReadLine();

            double allMoney = points * dancers;
            if (location == "Bulgaria")
            {
                if (season == "summer")
                    allMoney *= 0.95;
                else
                    allMoney *= 0.92;
            }
            else
            {
                allMoney *= 1.5;
                if (season == "summer")
                    allMoney *= 0.9;
                else
                    allMoney *= 0.85;
            }

            Console.WriteLine("Charity - {0:f2}", allMoney * 0.75);
            Console.WriteLine("Money per dancer - {0:f2}",allMoney*0.25/dancers);


        }
    }
}
