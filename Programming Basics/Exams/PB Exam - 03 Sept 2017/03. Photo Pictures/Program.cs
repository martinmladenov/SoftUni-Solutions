using System;

namespace _03.Photo_Pictures
{
    class Program
    {
        static void Main(string[] args)
        {
            int photos = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string order = Console.ReadLine();

            double price = 0;

            if (type == "9X13")
            {
                price = 0.16 * photos;
                if (photos >= 50) price *= 0.95;
            }
            else if (type == "10X15")
            {
                price = 0.16 * photos;
                if (photos >= 80) price *= 0.97;
            }
            else if (type == "13X18")
            {
                price = 0.38 * photos;
                if (photos > 100) price *= 0.95;
                else if (photos >= 50) price *= 0.97;
            }
            else if (type == "20X30")
            {
                price = 2.9 * photos;
                if (photos > 50) price *= 0.91;
                else if (photos >= 10) price *= 0.93;
            }

            if (order == "online")
                price *= 0.98;

            Console.WriteLine($"{price:f2}BGN");
        }
    }
}
