using System;

namespace _06.Catch_the_Thief
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            long maxValue = 0;
            switch (type)
            {
                case "sbyte":
                    maxValue = sbyte.MaxValue;
                    break;
                case "int":
                    maxValue = int.MaxValue;
                    break;
                case "long":
                    maxValue = long.MaxValue;
                    break;
            }
            long closest = long.MinValue;
            for (int i = 0; i < n; i++)
            {
                long id = long.Parse(Console.ReadLine());
                if (id <= maxValue && id > closest)
                    closest = id;
            }
            Console.WriteLine(closest);
        }
    }
}
