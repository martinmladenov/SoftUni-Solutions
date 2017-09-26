using System;

namespace _11._Odd_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            while ((i = int.Parse(Console.ReadLine())) % 2 == 0)
                Console.WriteLine("Please write an odd number.");

            Console.WriteLine("The number is: " + Math.Abs(i));
        }
    }
}
