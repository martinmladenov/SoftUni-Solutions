using System;

namespace _02._Passed_or_Failed
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(double.Parse(Console.ReadLine()) > 2.99 ? "Passed!" : "Failed!");
        }
    }
}
