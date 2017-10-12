namespace _06.Sum_Reversed_Numbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = Console.ReadLine()
                .Split()
                .Select(s => new string(s.Reverse().ToArray()))
                .Select(int.Parse)
                .Sum();
            Console.WriteLine(n);
        }
    }
}
