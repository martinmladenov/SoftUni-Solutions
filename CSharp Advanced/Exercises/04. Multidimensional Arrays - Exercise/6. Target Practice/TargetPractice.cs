namespace _6.Target_Practice
{
    using System;
    using System.Linq;

    public class TargetPractice
    {
        public static void Main()
        {
            int[] inputRowsCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = inputRowsCols[0];
            int cols = inputRowsCols[1];

            string snake = Console.ReadLine();

            int[] inputShot = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int shotRow = inputShot[0];
            int shotCol = inputShot[1];
            int shotRadius = inputShot[2];

            char[,] matrix = new char[rows, cols];

            int currSnakePos = 0;

            for (int row = 0; row < rows; row++)
            {
                int actualRow = rows - row - 1;
                for (int col = 0; col < cols; col++)
                {
                    int actualCol = row % 2 == 0 ? cols - col - 1 : col;

                    char snakeChar = snake[currSnakePos++];

                    if (Math.Sqrt(
                            Math.Pow(Math.Abs(actualCol - shotCol), 2) +
                            Math.Pow(Math.Abs(actualRow - shotRow), 2)
                        ) <= shotRadius)
                    {
                        snakeChar = ' ';
                    }

                    matrix[actualRow, actualCol] = snakeChar;

                    if (currSnakePos == snake.Length)
                    {
                        currSnakePos = 0;
                    }
                }
            }

            for (int row = rows - 1; row > 0; row--)
            {
                for (int col = 0; col < cols; col++)
                {
                    if(matrix[row,col] != ' ')
                        continue;

                    for (int checkRow = row-1; checkRow >=0; checkRow--)
                    {
                        if(matrix[checkRow,col] == ' ')
                            continue;

                        matrix[row, col] = matrix[checkRow, col];
                        matrix[checkRow, col] = ' ';

                        break;
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }

        }
    }
}
