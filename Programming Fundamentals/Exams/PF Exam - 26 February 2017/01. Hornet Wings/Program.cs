using System;

namespace _01.Hornet_Wings
{
    class Program
    {
        static void Main(string[] args)
        {

            int wingFlaps = int.Parse(Console.ReadLine());
            double distancePer1000 = double.Parse(Console.ReadLine());
            int endurance = int.Parse(Console.ReadLine());

            double meters = wingFlaps * distancePer1000 / 1000;
            int time = wingFlaps / 100 + wingFlaps / endurance * 5;

            Console.WriteLine($"{meters:f2} m.");
            Console.WriteLine($"{time} s.");

        }
    }
}
