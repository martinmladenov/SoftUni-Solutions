using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int left = 0;
            int right = 0;
            for (int i = 0; i < n; i++)
            {
                left += int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                right += int.Parse(Console.ReadLine());

            }
            
            if(left==right)
                Console.WriteLine($"Yes, sum = {left}");
            else
                Console.WriteLine($"No, diff = {Math.Abs(left-right)}");

        }
    }
}