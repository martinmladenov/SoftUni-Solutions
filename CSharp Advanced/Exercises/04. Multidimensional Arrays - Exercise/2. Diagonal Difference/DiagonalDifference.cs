namespace _2.Diagonal_Difference
{
    using System;

    public class DiagonalDifference
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                string[] input = Console.ReadLine().Split();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = int.Parse(input[col]);
                }
            }

            int primarySum = 0;
            int secondarySum = 0;
            for (int pos = 0; pos < n; pos++)
            {
                primarySum += matrix[pos, pos];
                secondarySum += matrix[pos, n - pos - 1];
            }

            int difference = Math.Abs(primarySum - secondarySum);

            Console.WriteLine(difference);

        }
    }
}
