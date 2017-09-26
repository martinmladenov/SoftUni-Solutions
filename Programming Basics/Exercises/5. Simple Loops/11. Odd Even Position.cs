using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            double oddsum = 0, oddmin = double.MaxValue, oddmax = double.MinValue, evensum = 0, evenmin = double.MaxValue, evenmax = double.MinValue;

            for (double i = 0; i < n; i++)
            {
                double o = double.Parse(Console.ReadLine());
                if(i % 2 == 1)
                {
                    evensum += o;
                    if (evenmin > o)
                        evenmin = o;
                    if (evenmax < o)
                        evenmax = o;
                }
                else
                {
                    oddsum += o;
                    if (oddmin > o)
                        oddmin = o;
                    if (oddmax < o)
                        oddmax = o;
                }
            }

            Console.WriteLine($"OddSum={oddsum}");
            Console.WriteLine("OddMin=" + ((n > 0) ? oddmin.ToString() : "No"));
            Console.WriteLine("OddMax=" + ((n > 0) ? oddmax.ToString() : "No"));

            Console.WriteLine($"EvenSum={evensum}");
            Console.WriteLine("EvenMin="+ ((n > 1) ? evenmin.ToString() : "No"));
            Console.WriteLine("EvenMax=" + ((n > 1) ? evenmax.ToString() : "No"));
        }
    }
}
