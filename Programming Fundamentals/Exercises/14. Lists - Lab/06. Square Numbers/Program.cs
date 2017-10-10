namespace _06.Square_Numbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();
            var squares = list
                .Where(i => Math.Sqrt(i) == (int)Math.Sqrt(i))
                .OrderByDescending(i => i)
                .ToList();
            Console.WriteLine(string.Join(" ", squares));
        }
    }
}
