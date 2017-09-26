using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int t = 1;
            while (t <= n)
            {
                Console.WriteLine(t);
                t = 2 * t + 1;
            }
        }
    }
}
