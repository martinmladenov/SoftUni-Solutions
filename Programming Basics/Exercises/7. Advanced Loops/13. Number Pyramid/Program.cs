using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int curr = 1;
            for (int cols = 1; curr <= n; cols++)
            {
                for (int i = 1; i <= cols && curr <= n; i++)
                {
                    Console.Write(curr + " ");
                    curr++;
                }
                Console.WriteLine();
            }

        }
    }
}
