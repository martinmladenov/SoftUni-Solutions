namespace _01.Dangerous_Floor
{
    using System;
    using System.Linq;

    public class DangerousFloor
    {
        public static void Main()
        {
            var board = new char[8, 8];
            for (int y = 0; y < 8; y++)
            {
                var pieces = Console.ReadLine()
                    .Split(',')
                    .Select(char.Parse)
                    .ToArray();
                for (int x = 0; x < 8; x++)
                    board[x, y] = pieces[x];
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                char piece = input[0];
                int fromY = input[1] - '0';
                int fromX = input[2] - '0';
                int toY = input[4] - '0';
                int toX = input[5] - '0';

                if (fromX >= 8 || fromX < 0 ||
                    fromY >= 8 || fromY < 0 ||
                    board[fromX, fromY] != piece)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }
                if (!IsMoveValid(piece, fromX, fromY, toX, toY, board))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }
                if (toX >= 8 || toX < 0 ||
                    toY >= 8 || toY < 0)
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }
                board[fromX, fromY] = 'x';
                board[toX, toY] = piece;
            }
        }

        private static bool IsMoveValid(char piece, int fromX, int fromY, int toX, int toY, char[,] board)
        {
            if (!IsVacant(toX, toY, board) ||
                fromX == toX &&
                fromY == toY)
                return false;

            switch (piece)
            {
                case 'K':
                    return Math.Abs(fromX - toX) <= 1 &&
                           Math.Abs(fromY - toY) <= 1;
                case 'R':
                    return CheckHorizontalVertical(fromX, fromY, toX, toY, board);
                case 'B':
                    return CheckDiagonal(fromX, fromY, toX, toY, board);
                case 'Q':
                    return CheckHorizontalVertical(fromX, fromY, toX, toY, board) ||
                           CheckDiagonal(fromX, fromY, toX, toY, board);
                case 'P':
                    return fromX == toX &&
                           toY == fromY - 1;
                default:
                    return true;
            }
        }

        private static bool CheckDiagonal(int fromX, int fromY, int toX, int toY, char[,] board)
        {
            if (Math.Abs(fromX - toX) != Math.Abs(fromY - toY))
                return false;
            int xDiff = fromX < toX ? 1 : -1;
            int yDiff = fromY < toY ? 1 : -1;

            for (int i = 1; i <= Math.Abs(fromX - toX); i++)
            {
                int currX = fromX + i * xDiff;
                int currY = fromY + i * yDiff;
                if (!IsVacant(currX, currY, board))
                    return false;
            }
            return true;
        }

        private static bool CheckHorizontalVertical(int fromX, int fromY, int toX, int toY, char[,] board)
        {
            if (fromX != toX && fromY != toY)
                return false;
            for (int x = Math.Min(fromX, toX); x <= Math.Max(fromX, toX); x++)
                for (int y = Math.Min(fromY, toY); y <= Math.Max(fromY, toY); y++)
                    if (x != fromX && y != fromY && !IsVacant(x, y, board))
                        return false;
            return true;
        }

        private static bool IsVacant(int x, int y, char[,] board)
        {
            return x < 0 || x >= 8 ||
                   y < 0 || y >= 8 ||
                 board[x, y] == 'x';
        }
    }
}
