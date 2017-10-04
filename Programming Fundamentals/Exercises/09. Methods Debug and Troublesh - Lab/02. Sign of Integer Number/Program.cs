using System;

namespace _02.Sign_of_Integer_Number
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintSign(number);
        }

        private static void PrintSign(int number)
        {
            Console.Write($"The number {number} is ");
            if (number > 0)
                Console.WriteLine("positive.");
            else if (number < 0)
                Console.WriteLine("negative.");
            else
                Console.WriteLine("zero.");
        }
    }
}