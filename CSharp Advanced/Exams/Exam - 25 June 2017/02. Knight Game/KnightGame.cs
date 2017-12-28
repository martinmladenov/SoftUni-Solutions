namespace _02.Knight_Game
{
    using System;

    public class KnightGame
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var board = new bool[n, n];
            for (int row = 0; row < n; row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < n; col++)
                    board[row, col] = line[col] == 'K';
            }

            int removed = 0;
            while (true)
            {
                var possibleAttacks = new int[n, n];

                for (var row = 0; row < n; row++)
                    for (var col = 0; col < n; col++)
                    {
                        if (!board[row, col])
                        {
                            possibleAttacks[row, col] = 0;
                            continue;
                        }
                        int attacks = 0;
                        if (!IsEmpty(row + 1, col + 2, board)) attacks++;
                        if (!IsEmpty(row + 2, col + 1, board)) attacks++;
                        if (!IsEmpty(row - 1, col + 2, board)) attacks++;
                        if (!IsEmpty(row - 2, col + 1, board)) attacks++;
                        if (!IsEmpty(row + 2, col - 1, board)) attacks++;
                        if (!IsEmpty(row + 1, col - 2, board)) attacks++;
                        if (!IsEmpty(row - 1, col - 2, board)) attacks++;
                        if (!IsEmpty(row - 2, col - 1, board)) attacks++;
                        possibleAttacks[row, col] = attacks;
                    }

                int removeRow = -1;
                int removeCol = -1;
                for (var row = 0; row < n; row++)
                    for (var col = 0; col < n; col++)
                        if (possibleAttacks[row, col] > (removeRow >= 0 ? possibleAttacks[removeRow, removeCol] : 0))
                        {
                            removeRow = row;
                            removeCol = col;
                        }
                if (removeRow == -1)
                    break;
                removed++;
                board[removeRow, removeCol] = false;
            }
            Console.WriteLine(removed);
        }

        private static bool IsEmpty(int x, int y, bool[,] board)
        {
            return x < 0 || x >= board.GetLength(0) ||
                   y < 0 || y >= board.GetLength(1) ||
                   !board[x, y];
        }
    }
}
