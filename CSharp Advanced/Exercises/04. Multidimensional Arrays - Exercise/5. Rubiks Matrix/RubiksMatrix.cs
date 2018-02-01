namespace _5.Rubiks_Matrix
{
    using System;
    using System.Linq;

    public class RubiksMatrix
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = row * cols + col + 1;
                }
            }

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                int index = int.Parse(line[0]);
                string direction = line[1];
                int moves = int.Parse(line[2]);

                if (direction == "up")
                {
                    int[] newColumn = new int[rows];
                    for (int j = 0; j < rows; j++)
                    {
                        int newIndex = (j - moves) % rows;
                        if (newIndex < 0)
                            newIndex += rows;
                        newColumn[newIndex] = matrix[j, index];
                    }

                    for (int j = 0; j < rows; j++)
                    {
                        matrix[j, index] = newColumn[j];
                    }
                }
                else if (direction == "down")
                {
                    int[] newColumn = new int[rows];
                    for (int j = 0; j < rows; j++)
                    {
                        int newIndex = (j + moves) % rows;
                        newColumn[newIndex] = matrix[j, index];
                    }

                    for (int j = 0; j < rows; j++)
                    {
                        matrix[j, index] = newColumn[j];
                    }
                }
                else if (direction == "left")
                {
                    int[] newRow = new int[cols];
                    for (int j = 0; j < cols; j++)
                    {
                        int newIndex = (j - moves) % cols;
                        if (newIndex < 0)
                            newIndex += cols;
                        newRow[newIndex] = matrix[index, j];
                    }

                    for (int j = 0; j < cols; j++)
                    {
                        matrix[index, j] = newRow[j];
                    }
                }
                else if (direction == "right")
                {
                    int[] newRow = new int[cols];
                    for (int j = 0; j < cols; j++)
                    {
                        int newIndex = (j + moves) % cols;
                        newRow[newIndex] = matrix[index, j];
                    }

                    for (int j = 0; j < cols; j++)
                    {
                        matrix[index, j] = newRow[j];
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int desired = row * cols + col + 1;
                    int current = matrix[row, col];
                    if (current == desired)
                    {
                        Console.WriteLine("No swap required");
                        continue;
                    }

                    int desiredRow = -1, desiredCol = -1;

                    for (int dRow = 0; dRow < rows && desiredRow == -1; dRow++)
                    {
                        for (int dCol = 0; dCol < cols && desiredRow == -1; dCol++)
                        {
                            if (matrix[dRow, dCol] != desired)
                                continue;

                            desiredRow = dRow;
                            desiredCol = dCol;
                        }
                    }

                    matrix[row, col] = desired;

                    matrix[desiredRow, desiredCol] = current;

                    Console.WriteLine("Swap ({0}, {1}) with ({2}, {3})",
                        row, col,
                        desiredRow, desiredCol);
                }
            }

            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        Console.Write(matrix[i, j] + " ");
            //    }

            //    Console.WriteLine();
            //}
        }
    }
}
