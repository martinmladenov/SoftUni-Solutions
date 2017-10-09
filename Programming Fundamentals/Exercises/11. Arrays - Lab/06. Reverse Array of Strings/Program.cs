namespace _06.Reverse_Array_of_Strings
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(string.Join(" ", Console.ReadLine().Split(' ').Reverse()));
        }
    }
}
