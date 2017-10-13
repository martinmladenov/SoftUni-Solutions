namespace _06.Heists
{
    using System;
    using System.Linq;

    public static class Heists
    {
        public static void Main()
        {
            var prices = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int jewelsPrice = prices[0];
            int goldPrice = prices[1];
            string input;
            long total = 0;
            while ((input = Console.ReadLine()) != "Jail Time")
            {
                var heist = input.Split();
                foreach (var c in heist[0])
                {
                    switch (c)
                    {
                        case '%':
                            total += jewelsPrice;
                            break;

                        case '$':
                            total += goldPrice;
                            break;
                    }
                }
                total -= int.Parse(heist[1]);
            }
            Console.WriteLine($"{(total >= 0 ? "Heists will continue. Total earnings:" : "Have to find another job. Lost:")} {Math.Abs(total)}.");
        }
    }
}
