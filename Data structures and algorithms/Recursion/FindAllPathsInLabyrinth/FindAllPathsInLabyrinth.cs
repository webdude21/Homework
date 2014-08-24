/* We are given a matrix of passable and non-passable cells. Write a recursive 
 * program for finding all paths between two cells in the matrix. */
namespace FindAllPathsInLabyrinth
{
    using System;
    using System.Collections.Generic;

    internal class FindAllPathsInLabyrinth
    {
        private const char Exit = 'e';

        private const char Free = ' ';

        private const char Up = 'U';

        private const char Blocked = '*';

        private const char Down = 'D';

        private const char Left = 'L';

        private const char Right = 'R';

        private const char Start = 'S';

        private static readonly List<char> Path = new List<char>();

        private static int pathsFound;

        private static readonly char[,] Labyrinth =
            {
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' }, 
                { '*', '*', ' ', '*', ' ', '*', ' ' }, 
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, 
                { ' ', '*', '*', ' ', '*', '*', ' ' }, 
                { ' ', ' ', ' ', ' ', ' ', ' ', 'e' }
            };

        private static void Main()
        {
            Path.Add(Start);
            Move(0, 0);
            Console.WriteLine("There ware {0} paths found!", pathsFound);
        }

        private static void Move(int row, int col)
        {
            if (Labyrinth[row, col] == Exit)
            {
                PrintPath();
                pathsFound++;
                Path.Clear();
                Path.Add(Start);
                return;
            }

            Labyrinth[row, col] = Blocked; // Occupy current Cell

            // Move Down
            if (row + 1 < Labyrinth.GetLength(0) && Labyrinth[row + 1, col] != Blocked)
            {
                Path.Add(Down);
                Move(row + 1, col);
            }

            // Move Right
            if (col + 1 < Labyrinth.GetLength(1) && Labyrinth[row, col + 1] != Blocked)
            {
                Path.Add(Right);
                Move(row, col + 1);
            }

            // Move Up
            if (row - 1 >= 0 && Labyrinth[row - 1, col] != Blocked)
            {
                Path.Add(Up);
                Move(row - 1, col);
            }

            // Move Left
            if (col - 1 >= 0 && Labyrinth[row, col - 1] != Blocked)
            {
                Path.Add(Left);
                Move(row, col - 1);
            }

            Labyrinth[row, col] = Free; // Free the current cell
        }

        private static void PrintPath()
        {
            Console.Write("The path used was: ");
            foreach (var direction in Path)
            {
                Console.Write(direction);
            }

            Console.WriteLine();
        }
    }
}