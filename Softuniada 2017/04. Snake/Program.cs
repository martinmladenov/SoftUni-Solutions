using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,,] cube = new char[size, size, size]; // row, column, layer
            int[] snakeLocation = new int[3];
            for (int currentRow = 0; currentRow < size; currentRow++)
            {
                string[] input = Console.ReadLine().Split(" | ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                for (int currentLayer = 0; currentLayer < size; currentLayer++)
                {
                    string layerPart = input[currentLayer];

                    for (int currentCol = 0; currentCol < size; currentCol++)
                    {
                        cube[currentRow, currentCol, currentLayer] = layerPart[currentCol];
                        if (layerPart[currentCol] == 's')
                        {
                            snakeLocation[0] = currentRow;
                            snakeLocation[1] = currentCol;
                            snakeLocation[2] = currentLayer;
                        }
                    }
                }
            }
            //            print cube
            //
            //            for (int layer = 0; layer < size; layer++)
            //            {
            //                for (int row = 0; row < size; row++)
            //                {
            //                    for (int col = 0; col < size; col++)
            //                    {
            //                        Console.Write(cube[row,col,layer]);
            //                    }
            //                    Console.WriteLine();
            //                }
            //                Console.WriteLine();
            //            }

            string direction = Console.ReadLine();
            bool dead = false;
            int points = 0;

            while (!dead)
            {
                string[] input = Console.ReadLine().Split();
                int steps = int.Parse(input[2]);
                for (int currentStep = 0; currentStep < steps; currentStep++)
                {
                    if (direction == "forward")
                        snakeLocation[0]--;
                    else if (direction == "backward")
                        snakeLocation[0]++;
                    else if (direction == "left")
                        snakeLocation[1]--;
                    else if (direction == "right")
                        snakeLocation[1]++;
                    else if (direction == "up")
                        snakeLocation[2]--;
                    else if (direction == "down")
                        snakeLocation[2]++;

                    //                    Console.WriteLine("snake loc: {0}, {1}, {2}", snakeLocation[0], snakeLocation[1], snakeLocation[2]);


                    if (snakeLocation[0] < 0 || snakeLocation[0] >= size ||
                        snakeLocation[1] < 0 || snakeLocation[1] >= size ||
                        snakeLocation[2] < 0 || snakeLocation[2] >= size)
                    {
                        //                        Console.WriteLine("ded");
                        dead = true;
                        break;
                    }
                    if (cube[snakeLocation[0], snakeLocation[1], snakeLocation[2]] == 'a')
                    {
                        points++;
                        cube[snakeLocation[0], snakeLocation[1], snakeLocation[2]] = 'o';
                        //                        Console.WriteLine("eat apple");
                    }

                }
                //                cube[snakeLocation[0], snakeLocation[1], snakeLocation[2]] = 'x';
                //                Console.WriteLine();
                //                Console.WriteLine();
                //                for (int layer = 0; layer < size; layer++)
                //                {
                //                    for (int row = 0; row < size; row++)
                //                    {
                //                        for (int col = 0; col < size; col++)
                //                        {
                //                            Console.Write(cube[row, col, layer]);
                //                        }
                //                        Console.WriteLine();
                //                    }
                //                    Console.WriteLine();
                //                }
                //                Console.WriteLine();

                direction = input[0];
                if (direction == "end")
                    break;
            }
            Console.WriteLine($"Points collected: {points}");
            if (dead)
                Console.WriteLine("The snake dies.");


        }
    }
}
