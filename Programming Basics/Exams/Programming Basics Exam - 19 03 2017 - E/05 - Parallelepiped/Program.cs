using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05___Parallelepiped
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = -1; i < 2 * n + 1; i++)
            {
                if (i == -1)
                {
                    Console.WriteLine("+" + new string('~', n - 2) + "+" + new string('.', 2 * n + 1));
                    continue;
                }
                Console.WriteLine("|" + new string('.', i) + "\\" + new string('~', n - 2) + "\\" + new string('.', 2 * n - i));
            }

            for (int i = 2 * n; i >= -1; i--)
            {
                if (i == -1)
                {
                    Console.WriteLine(new string('.', 2 * n + 1) + "+" + new string('~', n - 2) + "+");
                    continue;
                }
                Console.WriteLine(new string('.', 2 * n - i) + "\\" + new string('.', i) + "|" + new string('~', n - 2) + "|");
            }
        }
    }
}
