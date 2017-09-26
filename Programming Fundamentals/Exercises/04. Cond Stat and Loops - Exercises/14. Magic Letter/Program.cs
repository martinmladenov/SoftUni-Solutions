namespace _14.Magic_Letter
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char except = char.Parse(Console.ReadLine());
            for (char c1 = start; c1 <= end; c1++)
            {
                if (c1 == except) continue;
                for (char c2 = start; c2 <= end; c2++)
                {
                    if (c2 == except) continue;
                    for (char c3 = start; c3 <= end; c3++)
                    {
                        if (c3 == except) continue;
                        Console.Write("" + c1 + c2 + c3 + " ");
                    }
                }
            }
        }
    }
}
