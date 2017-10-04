using System;

namespace _08.Greater_of_Two_Values
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string type = Console.ReadLine();
            switch (type)
            {
                case "string":
                    {
                        string a = Console.ReadLine();
                        string b = Console.ReadLine();
                        Console.WriteLine(GetMax(a, b));
                        break;
                    }
                case "char":
                    {
                        char a = char.Parse(Console.ReadLine());
                        char b = char.Parse(Console.ReadLine());
                        Console.WriteLine(GetMax(a, b));
                        break;
                    }
                case "int":
                    {
                        int a = int.Parse(Console.ReadLine());
                        int b = int.Parse(Console.ReadLine());
                        Console.WriteLine(GetMax(a, b));
                        break;
                    }
            }
        }

        private static int GetMax(int a, int b)
        {
            return a >= b ? a : b;
        }

        private static char GetMax(char a, char b)
        {
            return a >= b ? a : b;
        }

        private static string GetMax(string a, string b)
        {
            return a.CompareTo(b) >= 0 ? a : b;
        }
    }
}