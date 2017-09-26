using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Energy_Loss
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dancers = int.Parse(Console.ReadLine());

            int energyUsed = 0;

            for (int training = 1; training <= days; training++)
            {
                int hours = int.Parse(Console.ReadLine());
                if (training % 2 == 0)
                {
                    if (hours % 2 == 0)
                        energyUsed += 68;
                    else
                        energyUsed += 65;
                }
                else
                {
                    if (hours % 2 == 0)
                        energyUsed += 49;
                    else
                        energyUsed += 30;
                }
            }
            double energyRemainingPerDay = 100 - 1d*energyUsed / days;

            Console.WriteLine("They {0}! Energy left: {1:f2}", energyRemainingPerDay >= 50 ? "feel good" : "are wasted", energyRemainingPerDay);
        }
    }
}
