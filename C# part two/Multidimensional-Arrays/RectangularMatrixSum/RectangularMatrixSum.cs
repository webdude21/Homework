// Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

using System;

internal class RectangularMatrixSum
{
    private static void Main()
    {
        GetMaxPlatformWithUserInput();

        // Test();
    }

    private static void FillMatixWithUserInput(int[,] matrix, int n, int m)
    {
        for (var row = 0; row < n; row++)
        {
            for (var col = 0; col < m; col++)
            {
                col = InputLine(matrix, row, col);
            }
        }
    }

    private static int InputLine(int[,] matrix, int row, int col)
    {
        // This is used for the input of each line. It also checks if the input is valid
        Console.Write("Please input an integer for element on position <{0},{1}> of the matrix: ", row, col);
        var result = int.TryParse(Console.ReadLine(), out matrix[row, col]);
        if (!result)
        {
            col--;
        }

        return col;
    }

    private static void FindMaxSum(int[,] matrix, int n, int m)
    {
        // This finds the biggest platform
        var maxSum = int.MinValue;
        var platform = new int[3, 3];
        var maxCol = 0;
        var maxRow = 0;
        for (var row = 1; row < n - 1; row++)
        {
            for (var col = 1; col < m - 1; col++)
            {
                platform = FillPlatform(matrix, row, col);
                var currentSum = SumPlatform(platform);
                if (currentSum > maxSum)
                {
                    maxCol = col;
                    maxRow = row;
                    maxSum = currentSum;
                }
            }
        }

        PrintResult(FillPlatform(matrix, maxRow, maxCol), maxSum);
    }

    private static void PrintResult(int[,] platform, int maxSum)
    {
        // As it says it just prints the platform in the end
        Console.WriteLine("This is the largest platform: ");
        for (var row = 0; row < 3; row++)
        {
            for (var col = 0; col < 3; col++)
            {
                Console.Write("<{0}>", platform[row, col]);
            }

            Console.WriteLine();
        }

        Console.WriteLine("The maximum sum is: {0}", maxSum);
    }

    private static int SumPlatform(int[,] platform)
    {
        // This sums the current platform (part of the matrix)
        var sum = 0;
        for (var row = 0; row < 3; row++)
        {
            for (var col = 0; col < 3; col++)
            {
                sum = sum + platform[row, col];
            }
        }

        return sum;
    }

    private static int[,] FillPlatform(int[,] matrix, int row, int col)
    {
        // This creates a new array with only the part of matrix we're checking now
        var numArray = new int[3, 3];
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

    private static void Test()
    {
        // This is a test matrix I've used during the testing of the program
        FindMaxSum(
            new[,]
                {
                    {
                       1, 2, 3, 5, 2, 52, 48, 56 
                    }, {
                          2, 3, 5, 72, 3, 72, 52, -50 
                       }, {
                             4, 16, 19, 2, 3, 4, -20, 15 
                          }, 
                    {
                       42, 15, 0, -10, 20, 15, -20, 60 
                    }, {
                          5, 8, 16, 9, 15, 2, -3, -15
                       },
                    { 6, 9, 5, 9, 10, -15, 55, 5 }
                },
            6,
            8);
    }

    private static void GetMaxPlatformWithUserInput()
    {
        // This part gets the user input
        Console.Write("Please input a valid integer for the N (it should be > 3): ");
        var n = int.Parse(Console.ReadLine());
        Console.Write("Please input a valid integer for the M (it should be > 3): ");
        var m = int.Parse(Console.ReadLine());
        var matrix = new int[n, m];
        FillMatixWithUserInput(matrix, n, m);
        FindMaxSum(matrix, n, m);
    }
}