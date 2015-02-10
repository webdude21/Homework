// Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)

namespace FillMatrix
{
    using System;

    internal class FillMatrix
    {
        private static void Main()
        {
            Console.Write("Please input a valid integer for the side of the matrix: ");
            var n = int.Parse(Console.ReadLine());
            Console.Write("Please input a, b, c, or d for the solution you need: ");
            var taskInput = Console.ReadLine();
            var taskLetter = taskInput[0];
            var matrix = new int[n, n];

            // Up to here I declare the variables to be used and validate the input
            // The case switch is for the user to choose which matrix to print
            switch (char.ToLower(taskLetter))
            {
                case 'a':
                    TaskVariantA(matrix, n);
                    break;
                case 'b':
                    TaskVariantB(matrix, n);
                    break;
                case 'c':
                    TaskVariantC(matrix, n);
                    break;
                case 'd':
                    TaskVariantD(matrix, n);
                    break;
                default:
                    Console.WriteLine("The input wasn't valid!");
                    return;
            }

            PrintMatrix(matrix, n);
        }

        private static void TaskVariantA(int[,] matrix, int n)
        {
            var index = 1;
            for (var row = 0; row < n; row++)
            {
                for (var col = 0; col < n; col++)
                {
                    matrix[col, row] = index;
                    index++;
                }
            }
        }

        private static void TaskVariantB(int[,] matrix, int n)
        {
            var index = 1;
            var flip = true;

            for (var row = 0; row < n; row++)
            {
                if (flip)
                {
                    for (var col = 0; col < n; col++)
                    {
                        matrix[col, row] = index;
                        index++;
                    }
                }
                else
                {
                    for (var col = n - 1; col >= 0; col--)
                    {
                        matrix[col, row] = index;
                        index++;
                    }
                }

                flip = !flip;
            }
        }

        private static void TaskVariantC(int[,] matrix, int n)
        {
            var rows = 0;
            var cols = 0;
            var index = 1;

            // populate values under the main diagonal
            for (var i = n - 1; i >= 0; i--)
            {
                rows = i;
                cols = 0;
                while (rows < n && cols < n)
                {
                    matrix[rows++, cols++] = index++;
                }
            }

            // populate values over the main diagonal
            for (var j = 1; j < n; j++)
            {
                rows = j;
                cols = 0;
                while (rows < n && cols < n)
                {
                    matrix[cols++, rows++] = index++;
                }
            }
        }

        private static void TaskVariantD(int[,] matrix, int n)
        {
            // For this solution I've used the part of the code from C# part 1 (from Loops)
            var row = 0;
            var col = 0;
            var direction = "down";
            var maxRotations = n * n;

            for (var index = 1; index <= maxRotations; index++)
            {
                if (direction == "down" && (row > n - 1 || matrix[row, col] != 0))
                {
                    direction = "right";
                    col++;
                    row--;
                }

                if (direction == "right" && (col > n - 1 || matrix[row, col] != 0))
                {
                    direction = "up";
                    row--;
                    col--;
                }

                if (direction == "up" && (row < 0 || matrix[row, col] != 0))
                {
                    direction = "left";
                    col--;
                    row++;
                }

                if (direction == "left" && (col < 0 || matrix[row, col] != 0))
                {
                    direction = "down";
                    row++;
                    col++;
                }

                matrix[row, col] = index;

                if (direction == "right")
                {
                    col++;
                }

                if (direction == "down")
                {
                    row++;
                }

                if (direction == "left")
                {
                    col--;
                }

                if (direction == "up")
                {
                    row--;
                }
            }
        }

        private static void PrintMatrix(int[,] matrix, int n)
        {
            for (var row = 0; row < n; row++)
            {
                for (var col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] > 9 ? "{0} " : " {0} ", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}