using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___Grape_and_Rakia
{
    class Program
    {
        static void Main(string[] args)
        {

            var area = double.Parse(Console.ReadLine());
            var kgPerSqM = double.Parse(Console.ReadLine());
            var remove = double.Parse(Console.ReadLine());

            var grapes = area * kgPerSqM - remove;

            var rakia = 0.45 * grapes / 7.5 * 9.8;
            var soldGrapes = 0.55 * grapes * 1.5;

            Console.WriteLine($"{rakia:f2}");
            Console.WriteLine($"{soldGrapes:f2}");

        }
    }
}
