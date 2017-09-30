using System;

namespace _18.Different_Integers_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberAsString = Console.ReadLine();
            bool canFit = false;

            try
            {
                var number = sbyte.Parse(numberAsString);
                Console.WriteLine(number + " can fit in:");
                canFit = true;
                Console.WriteLine("* sbyte");
            }
            catch (Exception) { /* ignored */ }

            try
            {
                var number = byte.Parse(numberAsString);
                if (!canFit)
                {
                    Console.WriteLine(number + " can fit in:");
                    canFit = true;
                }
                Console.WriteLine("* byte");
            }
            catch (Exception) { /* ignored */ }

            try
            {
                var number = short.Parse(numberAsString);
                if (!canFit)
                {
                    Console.WriteLine(number + " can fit in:");
                    canFit = true;
                }
                Console.WriteLine("* short");
            }
            catch (Exception) { /* ignored */ }

            try
            {
                var number = ushort.Parse(numberAsString);
                if (!canFit)
                {
                    Console.WriteLine(number + " can fit in:");
                    canFit = true;
                }
                Console.WriteLine("* ushort");
            }
            catch (Exception) { /* ignored */ }

            try
            {
                var number = int.Parse(numberAsString);
                if (!canFit)
                {
                    Console.WriteLine(number + " can fit in:");
                    canFit = true;
                }
                Console.WriteLine("* int");
            }
            catch (Exception) { /* ignored */ }

            try
            {
                var number = uint.Parse(numberAsString);
                if (!canFit)
                {
                    Console.WriteLine(number + " can fit in:");
                    canFit = true;
                }
                Console.WriteLine("* uint");
            }
            catch (Exception) { /* ignored */ }

            try
            {
                var number = long.Parse(numberAsString);
                if (!canFit)
                {
                    Console.WriteLine(number + " can fit in:");
                    canFit = true;
                }
                Console.WriteLine("* long");
            }
            catch (Exception) { /* ignored */ }

            if(!canFit)
                Console.WriteLine(numberAsString + " can't fit in any type");
        }
    }
}

