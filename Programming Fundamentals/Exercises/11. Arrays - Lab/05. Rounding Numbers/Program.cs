namespace _05.Rounding_Numbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            foreach (var i in array)
            {
                int rounded = (int)Math.Round(i, 0, MidpointRounding.AwayFromZero);
                Console.WriteLine($"{i} => {rounded}");
            }
        }
    }
}
