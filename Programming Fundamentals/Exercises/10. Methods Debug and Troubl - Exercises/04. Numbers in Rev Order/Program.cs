namespace _04.Numbers_in_Rev_Order
{
    using System;

    public class Program
    {
        public static void Main()
        {
            PrintReversed(Console.ReadLine());
        }

        public static void PrintReversed(string n)
        {
            string toPrint = string.Empty;
            bool isNegative = false;
            foreach (var c in n)
            {
                if (c != '-')
                    toPrint = c + toPrint;
                else
                    isNegative = true;
            }

            if (isNegative)
                Console.Write('-');
            Console.WriteLine(toPrint);
        }
    }
}
