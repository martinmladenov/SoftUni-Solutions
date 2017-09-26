using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Powers_of_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int t = 1;
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine(t);
                t *= 2;
            }
        }
    }
}
