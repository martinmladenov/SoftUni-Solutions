using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            int hr = int.Parse(Console.ReadLine());

            int min = int.Parse(Console.ReadLine()) + 15;

            if (min >= 60)
            {
                min -= 60;
                if (hr == 23)
                    hr = 0;
                else
                    hr++;
            }
            Console.WriteLine("{0}:{1:d2}", hr, min);

        }
    }
}