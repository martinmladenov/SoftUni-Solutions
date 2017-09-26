using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            string town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            double commission = -1;

            if (town == "Sofia")
            {
                if (sales <= 500) commission = 5;
                else if (sales <= 1000) commission = 7;
                else if (sales <= 10000) commission = 8;
                else commission = 12;
            }
            else if (town == "Varna")
            {
                if (sales <= 500) commission = 4.5;
                else if (sales <= 1000) commission = 7.5;
                else if (sales <= 10000) commission = 10;
                else commission = 13;
            }
            else if (town == "Plovdiv")
            {
                if (sales <= 500) commission = 5.5;
                else if (sales <= 1000) commission = 8;
                else if (sales <= 10000) commission = 12;
                else commission = 14.5;
            }

            double total = sales * commission / 100;

            if (commission < 0 || sales < 0)
                Console.WriteLine("error");
            else
                Console.WriteLine("{0:f2}", total);

        }
    }
}