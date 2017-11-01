namespace _01.Softuni_Coffee_Orders
{
    using System;
    using System.Linq;

    public class SoftuniCoffeeOrders
    {
        public static void Main()
        {
            int orders = int.Parse(Console.ReadLine());
            decimal total = 0;
            for (int i = 0; i < orders; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                var date = Console.ReadLine().Split('/').Select(int.Parse).Skip(1).Reverse().ToList();
                long count = long.Parse(Console.ReadLine());
                decimal price = count * DateTime.DaysInMonth(date[0], date[1]) * pricePerCapsule;
                Console.WriteLine($"The price for the coffee is: ${price:f2}");
                total += price;
            }
            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
