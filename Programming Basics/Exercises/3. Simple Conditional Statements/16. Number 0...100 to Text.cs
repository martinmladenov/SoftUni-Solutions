using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            int num = int.Parse(Console.ReadLine());

            if(num < 0 || num > 100)
                Console.WriteLine("invalid number");
            else if (num == 100)
                Console.Write("one hundred");
            else if (num == 0)
                Console.WriteLine("zero");
            else if (num >= 10 && num < 20)
            {
                if (num == 10)
                    Console.Write("ten");
                else if (num == 11)
                    Console.Write("eleven");
                else if (num == 12)
                    Console.Write("twelve");
                else if (num == 13)
                    Console.Write("thirteen");
                else if (num == 14)
                    Console.Write("fourteen");
                else if (num == 15)
                    Console.Write("fifteen");
                else if (num == 16)
                    Console.Write("sixteen");
                else if (num == 17)
                    Console.Write("seventeen");
                else if (num == 18)
                    Console.Write("eighteen");
                else if (num == 19)
                    Console.Write("nineteen");
            }
            else
            {
                int i1 = num / 10;
                int i2 = num % 10;

                if (i1 == 2)
                    Console.Write("twenty");
                else if (i1 == 3)
                    Console.Write("thirty");
                else if (i1 == 4)
                    Console.Write("forty");
                else if (i1 == 5)
                    Console.Write("fifty");
                else if (i1 == 6)
                    Console.Write("sixty");
                else if (i1 == 7)
                    Console.Write("seventy");
                else if (i1 == 8)
                    Console.Write("eighty");
                else if (i1 == 9)
                    Console.Write("ninety");

                if (i1 != 0 && i2 != 0)
                    Console.Write(" ");
                if(i2 == 1)
                    Console.Write("one");
                else if (i2 == 2)
                    Console.Write("two");
                else if (i2 == 3)
                    Console.Write("three");
                else if (i2 == 4)
                    Console.Write("four");
                else if (i2 == 5)
                    Console.Write("five");
                else if (i2 == 6)
                    Console.Write("six");
                else if (i2 == 7)
                    Console.Write("seven");
                else if (i2 == 8)
                    Console.Write("eight");
                else if (i2 == 9)
                    Console.Write("nine");
            }

        }
    }
}