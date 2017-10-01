using System;

namespace _14.Boat_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstBoatChar = char.Parse(Console.ReadLine());
            char secondBoatChar = char.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int firstBoatTiles = 0;
            int secondBoatTiles = 0;

            for (int i = 1; i <= n ; i++)
            {
                string input = Console.ReadLine();
                if (input == "UPGRADE")
                {
                    firstBoatChar += (char)3;
                    secondBoatChar += (char)3;
                    continue;
                }
                if (i % 2 == 1)
                    firstBoatTiles += input.Length;
                else
                    secondBoatTiles += input.Length;

                if(firstBoatTiles >= 50 || secondBoatTiles >= 50)
                    break;
            }

            Console.WriteLine(firstBoatTiles > secondBoatTiles ? firstBoatChar : secondBoatChar);
        }
    }
}
