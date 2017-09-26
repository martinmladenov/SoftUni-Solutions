using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Enter_Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            while (true)
            {
                Console.Write("Enter even number: ");
                string str = Console.ReadLine();
                try
                {
                    n = int.Parse(str);
                }
                catch
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }
                if (n % 2 != 0)
                    Console.WriteLine("The number is not even.");
                else
                    break;
            }
            Console.WriteLine("Even number entered: " + n);
        }
    }
}
