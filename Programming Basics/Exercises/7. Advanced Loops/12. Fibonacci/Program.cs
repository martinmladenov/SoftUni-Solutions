using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int prev = 1;
            int curr = 1;
            for (int i = 1; i < n; i++)
            {
                int t = curr;
                curr += prev;
                prev = t;
            }
            Console.WriteLine(curr);
        }
    }
}
