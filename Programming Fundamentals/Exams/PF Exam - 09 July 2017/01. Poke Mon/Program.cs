namespace _01.Poke_Mon
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int initialPokePower = pokePower;
            int pokedTargets = 0;
            while (pokePower >= distance)
            {
                pokedTargets++;
                pokePower -= distance;
                if (exhaustionFactor != 0 &&
                    100d * pokePower / initialPokePower == 50)
                {
                    pokePower /= exhaustionFactor;
                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(pokedTargets);
        }
    }
}
