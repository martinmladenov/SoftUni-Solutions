namespace _05.Fibonacci_Numbers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Fib(int.Parse(Console.ReadLine())));
        }

        public static long Fib(int n)
        {
            long a = 0;
            long b = 1;
            for (int i = 0; i < n; i++)
            {
                long tmp = a;
                a = b;
                b += tmp;
            }
            return b;
        }
    }
}
