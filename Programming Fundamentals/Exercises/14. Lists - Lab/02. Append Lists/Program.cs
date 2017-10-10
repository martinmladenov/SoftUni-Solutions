namespace _02.Append_Lists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<List<int>> lists = Console.ReadLine()
                .Split('|')
                .Select(s => s.Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList())
                .Reverse()
                .ToList();
            foreach (var list in lists)
                foreach (var i in list)
                    Console.Write(i + " ");
        }
    }
}
