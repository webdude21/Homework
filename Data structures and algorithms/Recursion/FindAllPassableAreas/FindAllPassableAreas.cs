/* We are given a matrix of passable and non-passable cells. Write a recursive program for 
 * finding all areas of passable cells in the matrix. */
namespace FindAllpassableAreas
{
    using System;

    internal class FindAllPassableAreas
    {
        private const char Free = ' ';

        private static readonly char[,] Labyrinth =
            {
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' }, 
                { '*', '*', ' ', '*', ' ', '*', ' ' }, 
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' }, 
                { '*', '*', '*', '*', '*', '*', '*' }, 
                { ' ', ' ', '*', '*', ' ', '*', ' ' }, 
                { '*', '*', ' ', '*', ' ', '*', ' ' }, 
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, 
                { '*', ' ', '*', '*', '*', '*', '*' }, 
                { ' ', ' ', '*', '*', ' ', '*', ' ' }, 
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' }, 
                { ' ', '*', '*', '*', '*', ' ', '*' }, 
                { ' ', ' ', ' ', ' ', ' ', '*', ' ' }, 
                { ' ', '*', '*', '*', '*', '*', '*' }, 
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' }
            };

        private static void Main()
        {
            var passableAreasCount = FindAllPassableCellAreas();
            PrintLabyrinth();
            Console.WriteLine();
            Console.WriteLine("There are {0} different areas of passable cells!", passableAreasCount);
        }

        private static void PrintLabyrinth()
        {
            for (var row = 0; row < Labyrinth.GetLength(0); row++)
            {
                for (var col = 0; col < Labyrinth.GetLength(1); col++)
                {
                    if (Labyrinth[row, col] >= 'A' && Labyrinth[row, col] < 'z')
                    {
                        Console.ForegroundColor = PickColor(row, col);
                    }

                    Console.Write("{0} ", Labyrinth[row, col]);
                    Console.ForegroundColor = ConsoleColor.Gray; // revert to default color
                }

                Console.WriteLine();
            }
        }

        private static ConsoleColor PickColor(int row, int col)
        {
            var currentColor = (ConsoleColor)((Labyrinth[row, col] - 'A' + 1) % 16);

            // If the color is black or standard grey, skip it
            if (currentColor == ConsoleColor.Gray || currentColor == ConsoleColor.Black)
            {
                currentColor++;
            }

            return currentColor;
        }

        private static int FindAllPassableCellAreas()
        {
            var currentPath = 'A';
            for (var row = 0; row < Labyrinth.GetLength(0); row++)
            {
                for (var col = 0; col < Labyrinth.GetLength(1); col++)
                {
                    if (Labyrinth[row, col] == Free)
                    {
                        Move(row, col, currentPath);
                        currentPath++;
                    }
                }
            }

            return currentPath - 'A';
        }

        private static void Move(int row, int col, char currentPath)
        {
            Labyrinth[row, col] = currentPath; // Ocuppy current Cell

            if (row + 1 < Labyrinth.GetLength(0) && Labyrinth[row + 1, col] == Free)
            {
                Move(row + 1, col, currentPath); // Move Down
            }

            if (col + 1 < Labyrinth.GetLength(1) && Labyrinth[row, col + 1] == Free)
            {
                Move(row, col + 1, currentPath); // Move Right
            }

            if (row - 1 >= 0 && Labyrinth[row - 1, col] == Free)
            {
                Move(row - 1, col, currentPath); // Move Up
            }

            if (col - 1 >= 0 && Labyrinth[row, col - 1] == Free)
            {
                Move(row, col - 1, currentPath); // Move Left
            }
        }
    }
}