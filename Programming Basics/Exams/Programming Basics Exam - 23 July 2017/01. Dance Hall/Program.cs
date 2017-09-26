using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {

            double l = double.Parse(Console.ReadLine())*100;
            double w = double.Parse(Console.ReadLine())*100;
            double a = double.Parse(Console.ReadLine())*100;

            double hall = 0.9 * l * w - a * a;
            int dancers = (int) Math.Floor(hall / 7040);
            Console.WriteLine(dancers);
        }
    }
}
