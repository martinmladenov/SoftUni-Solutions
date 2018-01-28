namespace _4.Pascal_Triangle
{
    using System;

    public class PascalTriangle
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            long[][] triangle = new long[n][];
            triangle[0] = new long[] { 1 };

            for (int row = 1; row < n; row++)
            {
                triangle[row] = new long[row + 1];

                for (int col = 0; col < row + 1; col++)
                {
                    long sum = 0;
                    if (col > 0)
                    {
                        sum += triangle[row - 1][col - 1];
                    }

                    if (col < row)
                    {
                        sum += triangle[row - 1][col];
                    }

                    triangle[row][col] = sum;


                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < row + 1; col++)
                {
                    Console.Write(triangle[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}