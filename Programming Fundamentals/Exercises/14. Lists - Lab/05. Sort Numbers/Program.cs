namespace _05.Sort_Numbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var list = Console.ReadLine().Split().Select(double.Parse).ToList();
            list.Sort();
            Console.WriteLine(string.Join(" <= ", list));
        }
    }
}
