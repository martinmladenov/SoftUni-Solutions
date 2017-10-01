using System;
namespace _07.Sentence_the_Thief
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            long maxValue = 0;
            long minValue = 0;
            switch (type)
            {
                case "sbyte":
                    maxValue = sbyte.MaxValue;
                    minValue = sbyte.MinValue;
                    break;
                case "int":
                    maxValue = int.MaxValue;
                    minValue = int.MinValue;
                    break;
                case "long":
                    maxValue = long.MaxValue;
                    minValue = long.MinValue;
                    break;
            }
            long closestId = long.MinValue;
            for (int i = 0; i < n; i++)
            {
                long id = long.Parse(Console.ReadLine());
                if (id <= maxValue && id >= minValue && id > closestId)
                    closestId = id;
            }
            long years = (long)Math.Ceiling((double)closestId / (closestId < 0 ? sbyte.MinValue : sbyte.MaxValue));

            Console.WriteLine($"Prisoner with id {closestId} is sentenced to {years} year{(years != 1 ? "s" : string.Empty)}");

        }
    }
}
