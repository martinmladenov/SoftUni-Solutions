using System;

namespace _02.Number_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            try
            {
                long.Parse(number);
                Console.WriteLine("integer");
                return;
            }
            catch (Exception)
            {
                // ignored
            }

            try
            {
                double.Parse(number);
                Console.WriteLine("floating-point");
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
