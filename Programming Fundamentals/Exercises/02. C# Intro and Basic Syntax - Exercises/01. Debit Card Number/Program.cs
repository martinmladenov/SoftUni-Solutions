using System;

namespace _01._Debit_Card_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"{int.Parse(Console.ReadLine()):d4} ");
            }
        }
    }
}
