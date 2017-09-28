using System;

namespace _06.DNA_Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetSum = int.Parse(Console.ReadLine());
            for (int i1 = 1; i1 <= 4; i1++)
                for (int i2 = 1; i2 <= 4; i2++)
                {
                    for (int i3 = 1; i3 <= 4; i3++)
                    {
                        string sequence = "" + GetChar(i1) + GetChar(i2) + GetChar(i3);
                        Console.Write("{0}{1}{0} ", i1 + i2 + i3 >= targetSum ? 'O' : 'X', sequence);
                    }
                    Console.WriteLine();
                }
        }

        static char GetChar(int i)
        {
            switch (i)
            {
                case 1:
                    return 'A';
                case 2:
                    return 'C';
                case 3:
                    return 'G';
                case 4:
                    return 'T';
                default:
                    return '0';
            }
        }
    }
}
