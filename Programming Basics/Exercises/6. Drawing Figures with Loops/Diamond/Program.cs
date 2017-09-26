using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //if (n < 3) return;
            Console.WriteLine("{0}{1}{0}", new string('-', (n - (n % 2 == 0 ? 2 : 1)) / 2), new string('*', n % 2 == 0 ? 2 : 1));
            for (int i = 1; i <= (n - 1) / 2; i++)
            {
                int mid = (n % 2 == 0 ? 2 : 1) + 2 * (i - 1);
                Console.WriteLine(new string('-', (n - 2 - mid) / 2) + "*" + new string('-', mid) + "*" +
                                  new string('-', (n - 2 - mid) / 2));
            }

            for (int i = (n - 1) / 2 - 1; i >= 1; i--)
            {
                int mid = (n % 2 == 0 ? 2 : 1) + 2 * (i - 1);
                Console.WriteLine(new string('-', (n - 2 - mid) / 2) + "*" + new string('-', mid) + "*" +
                                  new string('-', (n - 2 - mid) / 2));
            }
            if (n > 2)
                Console.WriteLine("{0}{1}{0}", new string('-', (n - (n % 2 == 0 ? 2 : 1)) / 2), new string('*', n % 2 == 0 ? 2 : 1));
        }
    }
}
