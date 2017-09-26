using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = int.Parse(Console.ReadLine());
            int dancers = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            double percent = Math.Ceiling(100d*steps/days/steps);
            double percentPerDancer = percent / dancers;
            if(percent <= 13)
                Console.WriteLine($"Yes, they will succeed in that goal! {percentPerDancer:f2}%.");
            else
                Console.WriteLine($"No, They will not succeed in that goal! Required {percentPerDancer:f2}% steps to be learned per day.");

        }
    }
}
