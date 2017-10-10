namespace _01.Remove_Negatives_and_Reverse
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(i => i >= 0)
                .Reverse()
                .ToList();
            Console.WriteLine(list.Count > 0 ? string.Join(" ", list) : "empty");
        }
    }
}
