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
                if(i%2==0)
                    left += int.Parse(Console.ReadLine());
                else
                    right += int.Parse(Console.ReadLine());

            }
            
            if(left==right)
                Console.WriteLine($"Yes, sum = {left}");
            else
                Console.WriteLine($"No, diff = {Math.Abs(left-right)}");

        }
    }
}