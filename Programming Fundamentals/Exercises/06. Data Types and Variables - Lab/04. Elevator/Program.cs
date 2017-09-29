using System;

namespace _04.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            Console.WriteLine(Math.Ceiling((double)people / capacity));
        }
    }
}
