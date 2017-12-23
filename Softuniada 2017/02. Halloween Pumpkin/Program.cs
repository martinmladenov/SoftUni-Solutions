using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Halloween_Pumpkin
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("{0}_/_{0}", new string('.',n-1));
            Console.WriteLine("/{0}^,^{0}\\",new string('.',n-2));

            for (int i = 0; i < n-3; i++)
                Console.WriteLine($"|{new string('.',n*2-1)}|");

            Console.WriteLine("\\{0}\\_/{0}/", new string('.', n - 2));
        }
    }
}
