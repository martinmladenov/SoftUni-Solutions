using System;

namespace _06.Strings_And_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            object o = s1 + " " + s2;
            string output = (string)o;
            Console.WriteLine(output);
        }
    }
}
