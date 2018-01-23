namespace _3.Decimal_to_Binary_Converter
{
    using System;
    using System.Collections.Generic;

    public class DecToBin
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var result = new Stack<int>();
            do
            {
                result.Push(n % 2);
                n /= 2;
            } while (n > 0);

            while (result.Count > 0)
            {
                Console.Write(result.Pop());
            }
        }
    }
}
