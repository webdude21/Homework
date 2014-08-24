/* We are given a matrix of passable and non-passable cells. Write a recursive 
 * program for finding all paths between two cells in the matrix. 
 * Modify the above program to check whether a path exists between two cells 
 * without finding all possible paths. Test it over an empty 100 x 100 matrix. */
namespace FindAtLeastOnePathInLabyrinth
{
    using System;
    using System.Collections.Generic;

    internal class FindAtLeastOnePathInLabyrinth
    {
        private const char Exit = 'e';

        private const char Free = ' ';

        private const char Up = 'U';

        private const char Blocked = '*';

        private const char Down = 'D';

        private const char Left = 'L';

        private const char Right = 'R';

        private const char Start = 'S';

        private const int LabyrinthSize = 4000; // yes it works with 4000 * 4000

        private static readonly LinkedList<char> Path = new LinkedList<char>();

        private static bool exitFound;

        private static readonly char[,] Labyrinth = new char[LabyrinthSize, LabyrinthSize];

        private static void Main()
        {
            Labyrinth[LabyrinthSize - 1, LabyrinthSize - 1] = Exit;
            Path.AddFirst(Start);
            Move(0, 0);
        }

        private static void Move(int row, int col)
        {
            if (Labyrinth[row, col] == Exit)
            {
                PrintPath();
                Console.WriteLine("The exit was found at [{0},{1}]", row, col);
                exitFound = true;
                return;
            }

            /* This is a sort of a second recursion bottom, 
             * if at least one path is found there's no need continue further */
            if (exitFound)
            {
                return;
            }

            Labyrinth[row, col] = Blocked; // Occupy current Cell

            // Move Down
            if (row + 1 < Labyrinth.GetLength(0) && Labyrinth[row + 1, col] != Blocked)
            {
                Path.AddLast(Down);
                Move(row + 1, col);
            }

            // Move Right
            if (col + 1 < Labyrinth.GetLength(1) && Labyrinth[row, col + 1] != Blocked)
            {
                Path.AddLast(Right);
                Move(row, col + 1);
            }

            // Move Up
            if (row - 1 >= 0 && Labyrinth[row - 1, col] != Blocked)
            {
                Path.AddLast(Up);
                Move(row - 1, col);
            }

            // Move Left
            if (col - 1 >= 0 && Labyrinth[row, col - 1] != Blocked)
            {
                Path.AddLast(Left);
                Move(row, col - 1);
            }

            Labyrinth[row, col] = Free; // Free the current cell
        }

        private static void PrintPath()
        {
            Console.WriteLine("The path used was:");
            foreach (var direction in Path)
            {
                Console.Write(direction);
            }

            Console.WriteLine();
        }
    }
}