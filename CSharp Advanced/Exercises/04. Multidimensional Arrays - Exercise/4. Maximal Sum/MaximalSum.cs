namespace _4.Maximal_Sum
{
    using System;
    using System.Linq;

    public class MaximalSum
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine().Split();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(line[col]);
                }
            }

            int maxSum = int.MinValue;
            int maxRow = 0, maxCol = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int sum = 0;

                    for (int rowOffset = 0; rowOffset <= 2; rowOffset++)
                    {
                        for (int colOffset = 0; colOffset <= 2; colOffset++)
                        {
                            sum += matrix[row + rowOffset, col + colOffset];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int rowOffset = 0; rowOffset <= 2; rowOffset++)
            {
                for (int colOffset = 0; colOffset <= 2; colOffset++)
                {
                    Console.Write(matrix[maxRow + rowOffset, maxCol + colOffset] + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
