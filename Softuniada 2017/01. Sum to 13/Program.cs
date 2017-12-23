using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sum_to_13
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] split = Console.ReadLine().Split();
            int a = int.Parse(split[0]);
            int b = int.Parse(split[1]);
            int c = int.Parse(split[2]);

            if (a + b + c == 13 ||
                -a + b + c == 13 ||
                a - b + c == 13 ||
                a + b - c == 13 ||
                -a - b + c == 13 ||
                -a + b - c == 13 ||
                a - b - c == 13 ||
                -a - b - c == 13)
                Console.WriteLine("Yes");
            else Console.WriteLine("No");

        }
    }
}
