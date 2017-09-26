using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            int i1 = int.Parse(Console.ReadLine());
            int i2 = int.Parse(Console.ReadLine());
            int i3 = int.Parse(Console.ReadLine());

            if (i1 == i2 && i2 == i3)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}