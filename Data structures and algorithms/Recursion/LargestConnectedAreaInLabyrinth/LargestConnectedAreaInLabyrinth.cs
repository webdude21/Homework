/* Write a recursive program to find the largest connected area of adjacent empty cells in a matrix. */
namespace LargestConnectedAreaInLabyrinth
{
    using System;

    internal class LargestConnectedAreaInLabyrinth
    {
        private const char Free = ' ';

        private const char Blocked = '*';

        private static int currentArea;

        private static int largestArea;

        private static readonly char[,] Labyrinth =
            {
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' }, 
                { '*', '*', ' ', '*', ' ', '*', ' ' }, 
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' }, 
                { ' ', '*', '*', '*', '*', '*', '*' }, 
                { ' ', ' ', '*', '*', ' ', ' ', ' ' }, 
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' }, 
                { ' ', '*', '*', '*', '*', '*', '*' }, 
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' }
            };

        private static void Main()
        {
            // Start from every possible position
            StartFromEveryPosition();
            Console.WriteLine("The largest connected area of adjacent empty cells contains {0} cells!", largestArea);
        }

        private static void StartFromEveryPosition()
        {
            for (var row = 0; row < Labyrinth.GetLength(0); row++)
            {
                for (var col = 0; col < Labyrinth.GetLength(1); col++)
                {
                    if (Labyrinth[row, col] == Free)
                    {
                        if (currentArea > largestArea)
                        {
                            largestArea = currentArea;
                        }

                        currentArea = 0;
                        Move(row, col);
                    }
                }
            }
        }

        private static void Move(int row, int col)
        {
            currentArea++;
            Labyrinth[row, col] = Blocked; // Occupy current Cell

            if (row + 1 < Labyrinth.GetLength(0) && Labyrinth[row + 1, col] != Blocked)
            {
                Move(row + 1, col); // Move Down
            }

            if (col + 1 < Labyrinth.GetLength(1) && Labyrinth[row, col + 1] != Blocked)
            {
                Move(row, col + 1); // Move Right
            }

            if (row - 1 >= 0 && Labyrinth[row - 1, col] != Blocked)
            {
                Move(row - 1, col); // Move Up
            }

            if (col - 1 >= 0 && Labyrinth[row, col - 1] != Blocked)
            {
                Move(row, col - 1); // Move Left
            }
        }
    }
}