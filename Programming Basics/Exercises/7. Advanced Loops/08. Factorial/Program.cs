using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int product = 1;
            do
                product *= n--;
            while (n > 0);
            Console.WriteLine(product);
        }
    }
}
