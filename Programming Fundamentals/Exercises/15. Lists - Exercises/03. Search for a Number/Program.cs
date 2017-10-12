namespace _03.Search_for_a_Number
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();
            var command = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int take = command[0];
            int delete = command[1];
            int n = command[2];
            Console.WriteLine(list.Skip(delete).Take(take - delete).Any(i => i == n) ? "YES!" : "NO!");
        }
    }
}
