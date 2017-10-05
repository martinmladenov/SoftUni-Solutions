namespace _02.Max_Method
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int max = GetMax(GetMax(a, b), c);
            Console.WriteLine(max);
        }

        public static int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }
    }
}
