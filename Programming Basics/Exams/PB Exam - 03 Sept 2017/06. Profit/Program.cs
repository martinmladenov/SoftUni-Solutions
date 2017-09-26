using System;

namespace _06.Profit
{
    class Program
    {
        static void Main(string[] args)
        {

            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            for (int i1 = 0; i1 <= n1; i1++)
                for (int i2 = 0; i2 <= n2; i2++)
                    for (int i3 = 0; i3 <= n3; i3++)
                        if (i1 * 1 + i2 * 2 + i3 * 5 == sum)
                            Console.WriteLine($"{i1} * 1 lv. + {i2} * 2 lv. + {i3} * 5 lv. = {sum} lv.");
        }
    }
}
