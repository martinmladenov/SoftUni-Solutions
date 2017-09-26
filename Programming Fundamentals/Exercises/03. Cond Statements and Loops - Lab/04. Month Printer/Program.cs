using System;

namespace _04._Month_Printer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months =
            {
                "January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
                "November", "December"
            };
            int n = int.Parse(Console.ReadLine());
            if (n < 1 || n > 12)
                Console.WriteLine("Error!");
            else
                Console.WriteLine(months[n-1]);
        }

    }
}
