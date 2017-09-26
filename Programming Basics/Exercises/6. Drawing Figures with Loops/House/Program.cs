using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < (n + 1) / 2; i++)
            {
                int stars = 2 * i + (n % 2 == 0 ? 2 : 1);
                Console.Write(new string('-', (n - stars) / 2));
                Console.Write(new string('*', stars));
                Console.WriteLine(new string('-', (n - stars) / 2));
            }
            for (int i = 0; i < n / 2; i++)
            {
                Console.Write('|');
                Console.Write(new string('*', n - 2));
                Console.WriteLine('|');

            }
        }
    }
}
