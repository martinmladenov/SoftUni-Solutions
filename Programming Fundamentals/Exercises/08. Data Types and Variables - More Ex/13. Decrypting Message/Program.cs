using System;

namespace _13.Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string message = string.Empty;
            for (int i = 0; i < n; i++)
                message += (char) (char.Parse(Console.ReadLine()) + key);
            Console.WriteLine(message);
        }
    }
}
