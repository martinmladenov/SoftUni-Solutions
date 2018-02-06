namespace _01._Sort_Even_Numbers
{
    using System;
    using System.Linq;

    public class SortEvenNumbers
    {
        public static void Main()
        {
            Console.WriteLine(string.Join(", ",
                Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(i => i % 2 == 0)
                .OrderBy(i => i)));
        }
    }
}
