using System;

namespace _05._Character_Stats
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Name: {Console.ReadLine()}");
            int health = int.Parse(Console.ReadLine());
            int healthMax = int.Parse(Console.ReadLine());
            int energy = int.Parse(Console.ReadLine());
            int energyMax = int.Parse(Console.ReadLine());
            Console.WriteLine($"Health: |{new string('|', health)}{new string('.', healthMax-health)}|");
            Console.WriteLine($"Energy: |{new string('|', energy)}{new string('.', energyMax-energy)}|");
        }
    }
}
