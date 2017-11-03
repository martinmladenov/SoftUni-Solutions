namespace _01.Sweet_Dessert
{
    using System;

    public class SweetDessert
    {
        public static void Main()
        {
            double money = double.Parse(Console.ReadLine());
            int guests = int.Parse(Console.ReadLine());
            double bananasPrice = double.Parse(Console.ReadLine());
            double eggsPrice = double.Parse(Console.ReadLine());
            double kiloBerriesPrice = double.Parse(Console.ReadLine());

            double cost = Math.Ceiling(guests / 6D) * (2 * bananasPrice + 4 * eggsPrice + 0.2 * kiloBerriesPrice);
            Console.WriteLine(cost <= money
                ? $"Ivancho has enough money - it would cost {cost:f2}lv."
                : $"Ivancho will have to withdraw money - he will need {cost - money:f2}lv more.");
        }
    }
}
