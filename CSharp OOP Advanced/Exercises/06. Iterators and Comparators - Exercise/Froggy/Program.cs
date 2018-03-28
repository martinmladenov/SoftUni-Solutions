namespace Froggy
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Lake lake = new Lake(Console.ReadLine().Split(", ").Select(int.Parse));

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
