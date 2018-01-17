namespace _02.Sort_Words
{
    using System;
    using System.Linq;

    public class SortWords
    {
        public static void Main()
        {
            var list = Console.ReadLine().Split().ToList();
            list.Sort();
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
