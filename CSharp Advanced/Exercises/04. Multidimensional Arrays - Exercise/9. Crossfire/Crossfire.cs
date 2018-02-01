namespace _9.Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Crossfire
    {
        public static void Main()
        {
            int[] inputRowsCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = inputRowsCols[0];
            int cols = inputRowsCols[1];

            List<List<int>> matrix = new List<List<int>>(rows);

            for (int row = 0; row < rows; row++)
            {
                matrix.Add(new List<int>(cols));
                for (int col = 0; col < cols; col++)
                {
                    matrix[row].Add(row * cols + col + 1);
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "Nuke it from orbit")
            {
                var split = input.Split()
                    .Select(int.Parse)
                    .ToArray();

                int figureRow = split[0];
                int figureCol = split[1];
                int radius = split[2];

                if (figureCol >= 0 && figureCol < cols)
                {
                    for (int row = Math.Max(0, figureRow - radius);
                        row <= Math.Min(matrix.Count - 1, figureRow + radius);
                        row++)
                    {
                        if (row != figureRow && matrix[row].Count > figureCol)
                        {
                            matrix[row].RemoveAt(figureCol);
                        }
                    }
                }

                if (figureRow >= 0 && figureRow < matrix.Count)
                {
                    for (int col = Math.Min(matrix[figureRow].Count - 1, figureCol + radius);
                    col >= Math.Max(0, figureCol - radius);
                    col--)
                    {
                        matrix[figureRow].RemoveAt(col);
                    }
                }

                for (int row = matrix.Count - 1; row >= 0; row--)
                {
                    if(matrix[row].Count==0)
                        matrix.RemoveAt(row);
                }
            }

            foreach (var row in matrix)
            {
                foreach (var col in row)
                {
                    Console.Write(col + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
