using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06___Control_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int control = int.Parse(Console.ReadLine());

            int moves = 0;
            int sum = 0;
            for (int i = 1; i <= n; i++)
                for (int j = m; j >= 1; j--)
                {
                    moves++;
                    sum += i * 2 + j * 3;
                    if (sum >= control)
                    {
                        Console.WriteLine($"{moves} moves");
                        Console.WriteLine($"Score: {sum} >= {control}");
                        return;
                    }
                }

            Console.WriteLine($"{moves} moves");
        }
    }
}
