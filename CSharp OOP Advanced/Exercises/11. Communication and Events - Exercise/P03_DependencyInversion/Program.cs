namespace P03_DependencyInversion
{
    using System;

    public class Program
    {
        public static void Main()
        {
            PrimitiveCalculator calc = new PrimitiveCalculator();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var split = input.Split();

                if (split[0] == "mode")
                {
                    calc.ChangeStrategy(split[1][0]);
                }
                else
                {
                    int i1 = int.Parse(split[0]);
                    int i2 = int.Parse(split[1]);
                    Console.WriteLine(calc.PerformCalculation(i1, i2));
                }
            }
        }
    }
}
