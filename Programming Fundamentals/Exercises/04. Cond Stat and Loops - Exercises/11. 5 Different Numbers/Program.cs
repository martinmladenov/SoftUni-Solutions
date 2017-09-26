using System;

namespace _11._5_Different_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            bool printed = false;

            for (int n1 = a; n1 <= b; n1++)
                for (int n2 = n1 + 1; n2 <= b; n2++)
                    for (int n3 = n2 + 1; n3 <= b; n3++)
                        for (int n4 = n3 + 1; n4 <= b; n4++)
                            for (int n5 = n4 + 1; n5 <= b; n5++)
                            {
                                printed = true;
                                Console.WriteLine($"{n1} {n2} {n3} {n4} {n5}");
                            }
            if (!printed) Console.WriteLine("No");

        }
    }
}
