namespace _12.String_Matrix_Rotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StringMatrixRotation
    {
        public static void Main()
        {
            string degreesStr = Console.ReadLine();
            int rotations = int.Parse(degreesStr.Substring(7, degreesStr.Length - 8)) % 360 / 90;
            List<string> lines = new List<string>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                lines.Add(input);
            }

            int longest = lines.Select(s => s.Length).Max();

            char[,] matrix = new char[lines.Count, longest];

            for (int row = 0; row < lines.Count; row++)
            {
                string line = lines[row];

                for (int col = 0; col < longest; col++)
                {
                    matrix[row, col] = col < line.Length ? line[col] : ' ';
                }
            }

            for (int i = 0; i < rotations; i++)
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);
                char[,] newMatrix = new char[cols, rows];

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        newMatrix[col, rows - row - 1] = matrix[row, col];
                    }
                }

                matrix = newMatrix;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
