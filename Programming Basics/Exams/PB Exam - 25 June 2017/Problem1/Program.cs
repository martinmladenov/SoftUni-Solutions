using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int cooks = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double totalPrice = (cakes * 45 + waffles * 5.8 + pancakes * 3.2) * days * cooks;
            totalPrice *= 0.875;
            Console.WriteLine(totalPrice.ToString("f2"));
        }
    }
}
