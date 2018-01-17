namespace _07.Distance_in_Labyrinth
{
    using System;
    using System.Linq;

    public class DistanceInLabyrinth
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var labyrinth = new Cell[n, n];

            int startCol = -1, startRow = -1;
            for (int col = 0; col < n; col++)
            {
                var line = Console.ReadLine();
                for (int row = 0; row < n; row++)
                {
                    if (line[row] == 'x')
                    {
                        labyrinth[col, row] = new Cell(true);
                        continue;
                    }

                    if (line[row] == '*')
                    {
                        startCol = col;
                        startRow = row;
                    }

                    labyrinth[col, row] = new Cell(false);
                }
            }

            Solve(labyrinth, startCol, startRow, 0);

            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    if (col == startCol && row == startRow)
                    {
                        Console.Write('*');
                    }
                    else if (labyrinth[col, row].Occupied)
                    {
                        Console.Write('x');
                    }
                    else if (labyrinth[col, row].Distance == int.MaxValue)
                    {
                        Console.Write('u');
                    }
                    else
                    {
                        Console.Write(labyrinth[col, row].Distance);
                    }
                }

                Console.WriteLine();
            }
        }

        private static void Solve(Cell[,] labyrinth, int col, int row, int currentDistance)
        {
            int n = labyrinth.GetLength(0);

            if (col >= n || row >= n ||
                col < 0 || row < 0 ||
                labyrinth[col, row].Occupied ||
                labyrinth[col, row].Distance <= currentDistance)
            {
                return;
            }

            labyrinth[col, row].Distance = currentDistance;

            currentDistance++;

            Solve(labyrinth, col + 1, row, currentDistance);
            Solve(labyrinth, col - 1, row, currentDistance);
            Solve(labyrinth, col, row + 1, currentDistance);
            Solve(labyrinth, col, row - 1, currentDistance);
        }
    }

    internal class Cell
    {
        public bool Occupied { get; }
        public int Distance { get; set; }

        public Cell(bool occupied)
        {
            Occupied = occupied;
            Distance = int.MaxValue;
        }
    }
}
