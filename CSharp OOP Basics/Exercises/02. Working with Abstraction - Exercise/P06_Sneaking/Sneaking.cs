using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] room = new char[n][];

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = input;
            }

            var moves = Console.ReadLine().ToCharArray();
            int[] samPos = new int[2];
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samPos[0] = row;
                        samPos[1] = col;
                    }
                }
            }

            foreach (var move in moves)
            {
                for (int row = 0; row < room.Length; row++)
                {
                    for (int col = 0; col < room[row].Length; col++)
                    {
                        if (room[row][col] == 'b')
                        {
                            if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                            {
                                room[row][col] = '.';
                                room[row][col + 1] = 'b';
                                col++;
                            }
                            else
                            {
                                room[row][col] = 'd';
                            }
                        }
                        else if (room[row][col] == 'd')
                        {
                            if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                            {
                                room[row][col] = '.';
                                room[row][col - 1] = 'd';
                            }
                            else
                            {
                                room[row][col] = 'b';
                            }
                        }
                    }
                }

                int[] nikoladzePos = new int[2];
                for (int j = 0; j < room[samPos[0]].Length; j++)
                {
                    if (room[samPos[0]][j] != '.' && room[samPos[0]][j] != 'S')
                    {
                        nikoladzePos[0] = samPos[0];
                        nikoladzePos[1] = j;
                    }
                }
                if (samPos[1] < nikoladzePos[1] && room[nikoladzePos[0]][nikoladzePos[1]] == 'd' && nikoladzePos[0] == samPos[0] ||
                    nikoladzePos[1] < samPos[1] && room[nikoladzePos[0]][nikoladzePos[1]] == 'b' && nikoladzePos[0] == samPos[0])
                {
                    room[samPos[0]][samPos[1]] = 'X';

                    Console.WriteLine($"Sam died at {samPos[0]}, {samPos[1]}");

                    break;
                }

                room[samPos[0]][samPos[1]] = '.';
                switch (move)
                {
                    case 'U':
                        samPos[0]--;
                        break;
                    case 'D':
                        samPos[0]++;
                        break;
                    case 'L':
                        samPos[1]--;
                        break;
                    case 'R':
                        samPos[1]++;
                        break;
                }
                room[samPos[0]][samPos[1]] = 'S';

                for (int j = 0; j < room[samPos[0]].Length; j++)
                {
                    if (room[samPos[0]][j] != '.' && room[samPos[0]][j] != 'S')
                    {
                        nikoladzePos[0] = samPos[0];
                        nikoladzePos[1] = j;
                    }
                }

                if (room[nikoladzePos[0]][nikoladzePos[1]] == 'N' && samPos[0] == nikoladzePos[0])
                {
                    room[nikoladzePos[0]][nikoladzePos[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    break;
                }
            }

            foreach (var row in room)
            {
                Console.WriteLine(new string(row));
            }
        }
    }
}
