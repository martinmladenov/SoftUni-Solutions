using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Name: {Console.ReadLine()}");
            Console.WriteLine($"Age: {Console.ReadLine()}");
            Console.WriteLine($"Employee ID: {int.Parse(Console.ReadLine()):d8}");
            Console.WriteLine($"Salary: {decimal.Parse(Console.ReadLine()):f2}");
        }
    }
}