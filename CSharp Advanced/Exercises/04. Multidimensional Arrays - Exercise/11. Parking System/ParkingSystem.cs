namespace _11.Parking_System
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingSystem
    {
        public static void Main()
        {
            int[] inputRowCol = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = inputRowCol[0];
            int cols = inputRowCol[1];

            HashSet<int>[] lot = new HashSet<int>[rows];

            for (int i = 0; i < rows; i++)
            {
                lot[i] = new HashSet<int>();
            }

            string input;
            while ((input = Console.ReadLine()) != "stop")
            {
                var split = input.Split().Select(int.Parse).ToArray();
                int entryRow = split[0];
                int spotRow = split[1];
                int spotCol = split[2];

                if (lot[spotRow].Contains(spotCol))
                {
                    int bestLength = cols;
                    int bestSpotCol = -1;

                    for (int newSpotCol = 1; newSpotCol < cols; newSpotCol++)
                    {
                        int currLength = Math.Abs(spotCol - newSpotCol);
                        if (!lot[spotRow].Contains(newSpotCol) && currLength < bestLength)
                        {
                            bestSpotCol = newSpotCol;
                            bestLength = currLength;
                        }
                    }

                    spotCol = bestSpotCol;
                }

                if (spotCol == -1)
                {
                    Console.WriteLine($"Row {spotRow} full");
                    continue;
                }

                lot[spotRow].Add(spotCol);
                Console.WriteLine(Math.Abs(entryRow - spotRow) + spotCol + 1);
            }
        }
    }
}
