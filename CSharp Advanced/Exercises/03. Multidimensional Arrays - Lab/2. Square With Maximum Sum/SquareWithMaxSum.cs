namespace _2.Square_With_Maximum_Sum
{
    using System;
    using System.Linq;

    public class SquareWithMaxSum
    {
        public static void Main()
        {
            int[] rowcol = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = rowcol[0];
            int cols = rowcol[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(line[col]);
                }
            }

            int maxRow = 0, maxCol = 0, maxSum = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int sum = matrix[row, col] +
                                  matrix[row + 1, col] +
                                  matrix[row, col + 1] +
                                  matrix[row + 1, col + 1];

                    if (sum > maxSum)
                    {
                        maxRow = row;
                        maxCol = col;
                        maxSum = sum;
                    }
                }
            }

            Console.Write(matrix[maxRow, maxCol] + " ");
            Console.WriteLine(matrix[maxRow, maxCol + 1]);
            Console.Write(matrix[maxRow + 1, maxCol] + " ");
            Console.WriteLine(matrix[maxRow + 1, maxCol + 1]);
            Console.WriteLine(maxSum);
        }
    }
}