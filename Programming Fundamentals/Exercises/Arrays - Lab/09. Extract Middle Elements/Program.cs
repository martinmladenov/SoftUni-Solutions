namespace _09.Extract_Middle_Elements
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            arr = arr.Skip(arr.Length / 2 - 1).Take(2 + arr.Length % 2).ToArray();
            Console.WriteLine("{{ {0} }}", string.Join(", ", arr));
        }
    }
}
