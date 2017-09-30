using System;

namespace _15.Fast_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberToCheck = int.Parse(Console.ReadLine());
            for (int currentNumber = 2; currentNumber <= numberToCheck; currentNumber++)
            { // should start from 2 instead of 0
                bool isPrime = true;
                for (int numberToDivideWith = 2; numberToDivideWith <= Math.Sqrt(currentNumber); numberToDivideWith++)
                {
                    if (currentNumber % numberToDivideWith == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{currentNumber} -> {isPrime}");
            }

        }
    }
}
