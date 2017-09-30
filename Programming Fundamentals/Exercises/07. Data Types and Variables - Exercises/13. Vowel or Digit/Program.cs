using System;

namespace _13.Vowel_or_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            char c = char.Parse(Console.ReadLine());
            if (c == 'a' || c == 'u' || c == 'o' || c == 'e' || c == 'i' || c == 'y')
                Console.WriteLine("vowel");
            else if (c >= '0' && c <= '9')
                Console.WriteLine("digit");
            else
                Console.WriteLine("other");
        }
    }
}
