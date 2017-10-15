namespace _01.Sort_Times
{
    using System;
    using System.Linq;

    public static class SortTimes
    {
        public static void Main()
        {
            Console.WriteLine(string.Join(", ",
                Console.ReadLine()
                .Split()
                .OrderBy(s => s)));
        }
    }
}
