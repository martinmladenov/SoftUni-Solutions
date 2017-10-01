using System;

namespace _08.House_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            int intPrice = 0;
            sbyte sbytePrice = 0;
            for (int i = 0; i < 2; i++)
            {
                string priceString = Console.ReadLine();
                try
                {
                    sbytePrice = sbyte.Parse(priceString);
                    continue;
                }
                catch (Exception)
                {
                    // ignored
                }
                intPrice = int.Parse(priceString);
            }
            Console.WriteLine(10L * intPrice + 4L * sbytePrice);
        }
    }
}
