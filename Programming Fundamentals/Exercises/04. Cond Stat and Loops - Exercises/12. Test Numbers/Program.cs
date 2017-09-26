using System;

namespace _12.Test_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxSum = int.Parse(Console.ReadLine());
            int counter = 0;
            int sum = 0;
            for (int i = a; i >= 1; i--)
                for (int j = 1; j <= b; j++)
                {
                    counter++;
                    if ((sum += 3 * i * j) < maxSum) continue;
                    Console.WriteLine($"{counter} combinations");
                    Console.WriteLine($"Sum: {sum} >= {maxSum}");
                    return;
                }
            Console.WriteLine($"{counter} combinations");
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
