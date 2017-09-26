namespace _15.Neighbour_Wars
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int peshoDamage = int.Parse(Console.ReadLine());
            int goshoDamage = int.Parse(Console.ReadLine());
            int peshoHealth = 100, goshoHealth = 100;
            for (int round = 1; ; round++)
            {
                if (round % 2 != 0)
                    goshoHealth -= peshoDamage;
                else
                    peshoHealth -= goshoDamage;

                if (peshoHealth * goshoHealth <= 0)
                {
                    Console.WriteLine($"{(round % 2 != 0 ? "Pesho" : "Gosho")} won in {round}th round.");
                    break;
                }
                Console.WriteLine($"{(round % 2 != 0 ? "Pesho" : "Gosho")} used {(round % 2 != 0 ? "Roundhouse kick" : "Thunderous fist")} and reduced {(round % 2 == 0 ? "Pesho" : "Gosho")} to {(round % 2 != 0 ? goshoHealth : peshoHealth)} health.");

                if (round % 3 != 0) continue;
                peshoHealth += 10;
                goshoHealth += 10;
            }

        }
    }
}
