namespace _04.Grab_and_Go
{
    using System;
    using System.Linq;

    public static class GrabAndGo
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split().Select(long.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            if (!arr.Contains(n))
            {
                Console.WriteLine("No occurrences were found!");
            }
            else
            {
                int index = Array.LastIndexOf(arr, n);
                Console.WriteLine(arr.Take(index).Sum());
            }
        }
    }
}
