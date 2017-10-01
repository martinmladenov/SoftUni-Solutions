using System;

namespace _03.Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            byte tank = 0;
            for (int i = 0; i < n; i++)
            {
                int liters = int.Parse(Console.ReadLine());
                if (liters + tank <= 255)
                    tank += (byte) liters;
                else
                    Console.WriteLine("Insufficient capacity!");
            }
            Console.WriteLine(tank);
        }
    }
}
