using System;

namespace _04._Beverage_Labels
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            double kcal = (double)int.Parse(Console.ReadLine()) * volume / 100;
            double sugar = (double)int.Parse(Console.ReadLine()) * volume / 100;
            Console.WriteLine($"{volume}ml {name}:\n{kcal}kcal, {sugar}g sugars");
        }
    }
}
