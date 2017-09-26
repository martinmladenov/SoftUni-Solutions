using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int max = 0;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int o = int.Parse(Console.ReadLine());
                sum += o;
                if (o > max)
                    max = o;
            }

            sum -= max;

            if (max == sum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {max}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(max-sum)}");
            }
        }
    }
}
