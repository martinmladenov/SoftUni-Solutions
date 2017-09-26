using System;

namespace Problem4
{
    class Program
    {
        static void Main(string[] args)
        {

            int parts = int.Parse(Console.ReadLine());
            double prizePerPoint = double.Parse(Console.ReadLine());
            int points = 0;
            for (int i = 0; i < parts; i++)
                points += int.Parse(Console.ReadLine()) * (i % 2 == 1 ? 2 : 1);
            Console.WriteLine($"The project prize was {points * prizePerPoint:f2} lv.");
        }
    }
}
