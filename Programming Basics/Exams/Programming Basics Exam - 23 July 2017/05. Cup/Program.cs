using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Cup
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}",
                    new string('.', n + i),
                    "#",
                    new string(i < n / 2 ? '#' : '.', 3 * n - 2 * i - 2));
            }
            Console.WriteLine("{0}{1}{0}",
                new string('.', 2 * n),
                new string('#', n));
            for (int i = 0; i < n + 2; i++)
            {
                if (i == n / 2)
                    Console.WriteLine("{0}{1}{0}",
                        new string('.', (5 * n - 10) / 2),
                        "D^A^N^C^E^");
                else
                    Console.WriteLine("{0}{1}{0}",
                        new string('.', 2 * n - 2),
                        new string('#', n + 4));
            }
        }
    }
}
