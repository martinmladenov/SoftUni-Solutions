using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double average = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double social = average > 4.5 && income < minSalary ? 0.35 * minSalary : 0;

            double excellentResults = average >= 5.5 ? average * 25 : 0;

            if (social == 0 && excellentResults == 0)
                Console.WriteLine("You cannot get a scholarship!");
            else if (social > excellentResults)
                Console.WriteLine($"You get a Social scholarship {Math.Floor(social)} BGN");
            else
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentResults)} BGN");

        }
    }
}
