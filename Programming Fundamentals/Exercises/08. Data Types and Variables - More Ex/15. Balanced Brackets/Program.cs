using System;

namespace _15.Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool opened = false;
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                if (line == "(")
                {
                    if (opened)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                    opened = true;
                }
                else if (line == ")")
                {
                    if (!opened)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                    opened = false;
                }
            }
            Console.WriteLine(opened ? "UNBALANCED" : "BALANCED");
        }
    }
}
