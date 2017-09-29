using System;

namespace _09.Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int currentNumber = 1; currentNumber <= maxNumber; currentNumber++)
            {
                var originalNumber = currentNumber;
                while (currentNumber > 0)
                {
                    sum += currentNumber % 10;
                    currentNumber = currentNumber / 10;
                }
                var isSpecial = sum == 5 || sum == 7 || sum == 11;
                Console.WriteLine($"{originalNumber} -> {isSpecial}");
                sum = 0;
                currentNumber = originalNumber;
            }

        }
    }
}
