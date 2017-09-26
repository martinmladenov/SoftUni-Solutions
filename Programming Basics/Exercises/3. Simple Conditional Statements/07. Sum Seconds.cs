using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int s1 = int.Parse(Console.ReadLine());
            int s2 = int.Parse(Console.ReadLine());
            int s3 = int.Parse(Console.ReadLine());

            int sum = s1 + s2 + s3;

            int min = sum / 60;
            int sec = sum % 60;

            Console.WriteLine("{0}:{1:d2}", min, sec);

        }
    }
}
