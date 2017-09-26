using System;

namespace _03._Miles_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{double.Parse(Console.ReadLine()) * 1.60934:f2}");
        }
    }
}
