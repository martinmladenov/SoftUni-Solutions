using System;

namespace _05.Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int sum = 0;
                int number = i;
                while (number > 0)
                {
                    sum += number % 10;
                    number /= 10;
                }
                Console.WriteLine("{0} -> {1}", i, sum == 5 || sum == 7 || sum == 11);
            }
        }
    }
}
