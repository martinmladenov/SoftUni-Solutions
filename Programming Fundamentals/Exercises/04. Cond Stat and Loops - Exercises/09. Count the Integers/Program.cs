using System;

namespace _09.Count_the_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            while (true)
            {
                try
                {
                    int.Parse(Console.ReadLine());
                    counter++;
                }
                catch (Exception)
                {
                    break;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
