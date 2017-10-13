namespace _04.Largest_3_Numbers
{
    using System;
    using System.Linq;

    public static class Largest3Numbers
    {
        public static void Main()
        {
            Console.WriteLine(string.Join(" ",
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderByDescending(i => i)
                .Take(3)
                ));
        }
    }
}
