using System;
using System.Linq;

namespace _03.Hornet_Assault
{
    class Program
    {
        static void Main(string[] args)
        {
            long currentDead = 0;
            var beehives =
                Array.ConvertAll(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries),
                    long.Parse);
            var hornets =
                Array.ConvertAll(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries),
                    long.Parse);
            long powerSum = hornets.Sum();

            bool prlongBeehives = false;
            for (var index = 0; index < beehives.Length; index++)
            {
                var beehive = beehives[index];

                beehives[index] -= powerSum;

                if (beehive < powerSum) continue;
                if (beehive > powerSum) prlongBeehives = true;

                if (currentDead >= hornets.Length)
                    break;
                powerSum -= hornets[currentDead];
                currentDead++;
            }

            if (prlongBeehives)
            {
                foreach (var beehive in beehives)
                    if (beehive > 0)
                        Console.Write(beehive + " ");
            }
            else
                for (var index = currentDead; index < hornets.Length; index++)
                    Console.Write(hornets[index] + " ");
        }
    }
}
