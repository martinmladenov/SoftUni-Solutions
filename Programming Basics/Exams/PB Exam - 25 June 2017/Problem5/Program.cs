using System;

namespace Problem5
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(new string('#', 4 * n + 1));
            for (int i = 1; i <= n; i++)
            {
                if (i == n / 2 + 1)
                    Console.WriteLine("{0}{1}{2}(@){2}{1}{0}",
                        new string('.', i),
                        new string('#', 2 * n - 1 - 2 * (i - 1)),
                        new string(' ', (1 + 2 * (i - 1) - 3) / 2));
                else
                    Console.WriteLine("{0}{1}{2}{1}{0}",
                        new string('.', i),
                        new string('#', 2 * n - 1 - 2 * (i - 1)),
                        new string(' ', 1 + 2 * (i - 1)));
            }

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}{1}{0}",
                    new string('.', n + i),
                    new string('#', 2 * n - 1 - 2 * (i - 1)));
            }

        }
    }
}
