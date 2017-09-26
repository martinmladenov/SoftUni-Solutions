using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Number_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int k = i + j + 1;
                    if (k > n)
                        k = 2 * n - k;
                    Console.Write(k + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
