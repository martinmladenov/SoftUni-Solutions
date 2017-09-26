using System;

namespace _01.Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {

            int tables = int.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            double karetaPlosht = Math.Pow(length / 2, 2);

            double pokrivkiPlosht = (length + 0.6) * (width + 0.6);

            double totalPrice = (karetaPlosht * 9 + pokrivkiPlosht * 7) * tables;

            Console.WriteLine($"{totalPrice:f2} USD");
            Console.WriteLine($"{totalPrice * 1.85:f2} BGN");

        }
    }
}
