using System;

namespace _06.Interval_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            if (start > end)
            {
                int tmp = start;
                start = end;
                end = tmp;
            }
            for (int i = start; i <= end; i++)
                Console.WriteLine(i);
        }
    }
}
