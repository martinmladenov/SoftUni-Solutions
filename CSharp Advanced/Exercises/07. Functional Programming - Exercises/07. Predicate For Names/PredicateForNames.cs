namespace _07._Predicate_For_Names
{
    using System;
    using System.Linq;

    public class PredicateForNames
    {
        public static void Main()
        {
            int maxLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string[], string[]> removeWithGreaterLength = arr => arr.Where(s => s.Length <= maxLength).ToArray();

            Action<string[]> printAction = arr =>
            {
                foreach (var s in arr)
                {
                    Console.WriteLine(s);
                }
            };

            printAction(removeWithGreaterLength(names));
        }
    }
}
