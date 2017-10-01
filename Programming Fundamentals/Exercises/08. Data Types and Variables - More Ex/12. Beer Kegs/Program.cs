using System;

namespace _12.Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double biggestVolume = 0;
            string biggestModel = string.Empty;
            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double r = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                double volume = r * r * h * Math.PI;
                if (volume > biggestVolume)
                {
                    biggestVolume = volume;
                    biggestModel = model;
                }
            }

            Console.WriteLine(biggestModel);
        }
    }
}
