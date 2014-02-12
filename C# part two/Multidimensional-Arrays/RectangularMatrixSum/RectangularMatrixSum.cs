// Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

using System;

class RectangularMatrixSum
{
    static void Main()
    {
        // I've had many comments on this task but the source code file got lost :(
        // I've recovered the program using JustDecompile, but the comments are shorter this time
        GetMaxPlatformWithUserInput();
        //Test();
    }

    static void FillMatixWithUserInput(int[,] matrix, int n, int m)
    {
        // This gets the user to input each and every 
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                col = RectangularMatrixSum.InputLine(matrix, row, col);
            }
        }
    }

    static int InputLine(int[,] matrix, int row, int col)
    {
        // This is used for the input of each line. It also checks if the input is valid
        Console.Write("Please input an integer for element on position <{0},{1}> of the matrix: ", row, col);
        bool result = int.TryParse(Console.ReadLine(), out matrix[row, col]);
        if (!result)
        {
            col--;
        }
        return col;
    }

    static void FindMaxSum(int[,] matrix, int n, int m)
    {
        // This finds the biggest platform
        int maxSum = int.MinValue;
        int[,] platform = new int[3, 3];
        int maxCol = 0;
        int maxRow = 0;
        for (int row = 1; row < n - 1; row++)
        {
            for (int col = 1; col < m - 1; col++)
            {
                platform = RectangularMatrixSum.FillPlatform(matrix, row, col);
                int currentSum = RectangularMatrixSum.SumPlatform(platform);
                if (currentSum > maxSum)
                {
                    maxCol = col;
                    maxRow = row;
                    maxSum = currentSum;
                }
            }
        }
        RectangularMatrixSum.PrintResult(RectangularMatrixSum.FillPlatform(matrix, maxRow, maxCol), maxSum);
    }
    static void PrintResult(int[,] platform, int maxSum)
    {
        // As it says it just prints the platform in the end
        Console.WriteLine("This is the largest platform: ");
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                Console.Write("<{0}>", platform[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("The maximum sum is: {0}", maxSum);
    }

    static int SumPlatform(int[,] platform)
    {
        // This sums the current platform (part of the matrix)
        int sum = 0;
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                sum = sum + platform[row, col];
            }
        }
        return sum;
    }

    static int[,] FillPlatform(int[,] matrix, int row, int col)
    {
        // This creates a new array with only the part of matrix we're checking now
        int[,] numArray = new int[3, 3];
        numArray[0, 0] = matrix[row - 1, col - 1];
        numArray[0, 1] = matrix[row - 1, col];
        numArray[0, 2] = matrix[row - 1, col + 1];
        numArray[1, 0] = matrix[row, col - 1];
        numArray[1, 1] = matrix[row, col];
        numArray[1, 2] = matrix[row, col + 1];
        numArray[2, 0] = matrix[row + 1, col - 1];
        numArray[2, 1] = matrix[row + 1, col];
        numArray[2, 2] = matrix[row + 1, col + 1];
        return numArray;
    }
    static void Test()
    {
        // This is a test matrix i've used during the testing of the program
        RectangularMatrixSum.FindMaxSum(new int[,] { { 1, 2, 3, 5, 2, 52, 48, 56 },
        { 2, 3, 5, 72, 3, 72, 52, -50 }, 
        { 4, 16, 19, 2, 3, 4, -20, 15 }, 
        { 42, 15, 0, -10, 20, 15, -20, 60 }, 
        { 5, 8, 16, 9, 15, 2, -3, -15 }, 
        { 6, 9, 5, 9, 10, -15, 55, 5 } }, 6, 8);
    }
    static void GetMaxPlatformWithUserInput()
    {
        // This part gets the user input
        Console.Write("Please input a valid integer for the N (it should be > 3): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Please input a valid integer for the M (it should be > 3): ");
        int m = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, m];
        RectangularMatrixSum.FillMatixWithUserInput(matrix, n, m);
        RectangularMatrixSum.FindMaxSum(matrix, n, m);
    }
}