// Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)

using System;

class FillMatrix
{
    static void Main()
    {
        char taskLetter = ' ';
        string taskInput;
        Console.Write("Please input a valid integer for the side of the matrix: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Please input a, b, c, or d for the solution you need: ");
        taskInput = Console.ReadLine();
        taskLetter = (char)taskInput[0];
        int[,] matrix = new int[n, n];

        // Up to here I declare the variables to be used and validate the input
        // The case switch is for the user to choose which matrix to print
        switch (taskLetter)
        {
            case 'a':
            case 'A':
                TaskVariantA(matrix, n);
                break;
            case 'b':
            case 'B':
                TaskVariantB(matrix, n);
                break;
            case 'c':
            case 'C':
                TaskVariantC(matrix, n);
                break;
            case 'd':
            case 'D':
                TaskVariantD(matrix, n);
                break;
            default:
                Console.WriteLine("The input wasn't valid!");
                break;
        }

        PrintMatrix(matrix, n);
    }

    static void TaskVariantA(int[,] matrix, int n)
    {
        int index = 1;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                matrix[col, row] = index;
                index++;
            }
        }
    }

    static void TaskVariantB(int[,] matrix, int n)
    {
        int index = 1;
        bool flip = true;

        for (int row = 0; row < n; row++)
        {
            if (flip)
            {
                for (int col = 0; col < n; col++)
                {
                    matrix[col, row] = index;
                    index++;
                }

                flip = !flip;
            }
            else
            {
                for (int col = n - 1; col >= 0; col--)
                {
                    matrix[col, row] = index;
                    index++;
                }

                flip = !flip;
            }
        }
    }

    static void TaskVariantC(int[,] matrix, int n)
    {
        int rows = 0;
        int cols = 0;
        int index = 1;

        //populate values under the main diagonal
        for (int i = n - 1; i >= 0; i--)
        {
            rows = i;
            cols = 0;
            while (rows < n && cols < n)
            {
                matrix[rows++, cols++] = index++;
            }
        }

        //populate values over the main diagonal
        for (int j = 1; j < n; j++)
        {
            rows = j;
            cols = 0;
            while (rows < n && cols < n)
            {
                matrix[cols++, rows++] = index++;
            }
        }
    }

    static void TaskVariantD(int[,] matrix, int n)
    {
        // For this solution I've used the part of the code from C# part 1 (from Loops)
        int row = 0;
        int col = 0;
        string direction = "down";
        int maxRotations = n * n;

        for (int index = 1; index <= maxRotations; index++)
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

    static void PrintMatrix(int[,] matrix, int n)
    {
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (matrix[row, col] > 9)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }
                else
                {
                    Console.Write(" {0} ", matrix[row, col]);
                }
            }
            Console.WriteLine();
        }
    }
}