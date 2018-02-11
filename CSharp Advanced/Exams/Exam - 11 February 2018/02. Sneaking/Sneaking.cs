namespace _02._Sneaking
{
    using System;

    public class Sneaking
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char[][] room = new char[n][];

            int samRow = -1;
            int samCol = -1;

            int nikoladzeRow = -1;
            int nikoladzeCol = -1;

            for (int row = 0; row < n; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samCol = col;
                        samRow = row;
                        room[row][col] = '.';
                    }
                    else if (room[row][col] == 'N')
                    {
                        nikoladzeRow = row;
                        nikoladzeCol = col;
                    }
                }
            }

            string directions = Console.ReadLine();

            foreach (char direction in directions)
            {
                // Move enemies

                bool[,] movedThisTurn = new bool[n, room[0].Length];

                for (int row = 0; row < n; row++)
                {
                    if (row == nikoladzeRow)
                    {
                        continue;
                    }

                    for (int col = 0; col < room[row].Length; col++)
                    {

                        if (movedThisTurn[row, col])
                        {
                            continue;
                        }
                        if (room[row][col] == 'b')
                        {
                            if (col == room[row].Length - 1)
                            {
                                room[row][col] = 'd';
                            }
                            else
                            {
                                room[row][col] = '.';
                                room[row][col + 1] = 'b';
                                movedThisTurn[row, col + 1] = true;
                            }
                        }
                        else if (room[row][col] == 'd')
                        {
                            if (col == 0)
                            {
                                room[row][col] = 'b';
                            }
                            else
                            {
                                room[row][col] = '.';
                                room[row][col - 1] = 'd';
                                movedThisTurn[row, col - 1] = true;
                            }
                        }

                    }
                }

                // Check if Sam should die
                bool samDead = false;
                for (int col = 0; col < room[samRow].Length; col++)
                {
                    if (room[samRow][col] == 'b' && samCol > col ||
                        room[samRow][col] == 'd' && samCol < col)
                    {
                        samDead = true;
                        break;
                    }
                }

                if (samDead)
                {
                    room[samRow][samCol] = 'X';
                    Console.WriteLine($"Sam died at {samRow}, {samCol}");
                    break;
                }

                // Move Sam

                if (direction == 'U')
                {
                    samRow--;
                }
                else if (direction == 'D')
                {
                    samRow++;
                }
                else if (direction == 'L')
                {
                    samCol--;
                }
                else if (direction == 'R')
                {
                    samCol++;
                }

                // Check if Sam kills Nikoladze

                if (samRow == nikoladzeRow)
                {
                    room[nikoladzeRow][nikoladzeCol] = 'X';
                    room[samRow][samCol] = 'S';
                    Console.WriteLine("Nikoladze killed!");
                    break;
                }

                // Remove enemy if killed by Sam

                room[samRow][samCol] = '.';
            }

            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(new string(room[row]));
            }
        }
    }
}