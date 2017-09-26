using System;

namespace Problem6
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool found = false;
            for (int a = 1; a <= 30; a++)
                for (int b = 1; b <= 30; b++)
                    for (int c = 1; c <= 30; c++)
                    {
                        if (a < b && b < c && a + b + c == n)
                        {
                            Console.WriteLine($"{a} + {b} + {c} = {n}");
                            found = true;
                        }
                        if (a > b && b > c && a * b * c == n)
                        {
                            Console.WriteLine($"{a} * {b} * {c} = {n}");
                            found = true;
                        }
                    }

            if(!found)
                Console.WriteLine("No!");

        }
    }
}
