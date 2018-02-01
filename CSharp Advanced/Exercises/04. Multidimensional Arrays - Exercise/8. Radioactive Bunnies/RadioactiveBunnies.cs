namespace _8.Radioactive_Bunnies
{
    using System;
    using System.Linq;

    public class RadioactiveBunnies
    {
        public static void Main()
        {
            int[] inputRowsCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = inputRowsCols[0];
            int cols = inputRowsCols[1];

            bool[,] bunnies = new bool[rows, cols];

            int playerRow = -1, playerCol = -1;

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    char current = input[col];
                    if (current == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    bunnies[row, col] = current == 'B';
                }
            }

            string commands = Console.ReadLine();

            bool escaped = false;

            foreach (var command in commands)
            {
                // Calculate new player position and break if escaped

                int targetRow = playerRow;
                int targetCol = playerCol;
                switch (command)
                {
                    case 'R':
                        targetCol++;
                        break;
                    case 'L':
                        targetCol--;
                        break;
                    case 'D':
                        targetRow++;
                        break;
                    case 'U':
                        targetRow--;
                        break;
                }

                if (targetCol < 0 || targetCol >= cols ||
                    targetRow < 0 || targetRow >= rows)
                {
                    escaped = true;
                }

                // Spread bunnies

                bool[,] newBunnies = new bool[rows, cols];

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (!bunnies[row, col] || newBunnies[row, col])
                            continue;


                        if (row > 0 && !bunnies[row - 1, col])
                        {
                            bunnies[row - 1, col] = true;
                            newBunnies[row - 1, col] = true;
                        }

                        if (row < rows - 1 && !bunnies[row + 1, col])
                        {
                            bunnies[row + 1, col] = true;
                            newBunnies[row + 1, col] = true;
                        }

                        if (col > 0 && !bunnies[row, col - 1])
                        {
                            bunnies[row, col - 1] = true;
                            newBunnies[row, col - 1] = true;
                        }

                        if (col < cols - 1 && !bunnies[row, col + 1])
                        {
                            bunnies[row, col + 1] = true;
                            newBunnies[row, col + 1] = true;
                        }
                    }
                }



                // Move player

                if (!escaped)
                {
                    playerRow = targetRow;
                    playerCol = targetCol;
                }

                // Break if player is dead or escaped

                if (escaped || bunnies[playerRow, playerCol])
                {
                    break;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(bunnies[row, col] ? 'B' : '.');
                }

                Console.WriteLine();
            }

            Console.WriteLine($"{(escaped ? "won" : "dead")}: {playerRow} {playerCol}");

        }
    }
}
