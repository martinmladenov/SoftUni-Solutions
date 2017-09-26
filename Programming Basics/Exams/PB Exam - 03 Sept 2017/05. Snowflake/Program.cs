using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Snowflake
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n - 1; i++)
                Console.WriteLine("{0}*{1}*{1}*{0}",
                    new string('.', i),
                    new string('.', n - i));
            Console.WriteLine("{0}*****{0}", new string('.', n - 1));
            Console.WriteLine(new string('*', 2 * n + 3));
            Console.WriteLine("{0}*****{0}", new string('.', n - 1));
            for (int i = n - 1 - 1; i >= 0; i--)
                Console.WriteLine("{0}*{1}*{1}*{0}",
                    new string('.', i),
                    new string('.', n - i));
        }
    }
}
