// Write a program that reads a text file containing a square matrix of numbers and finds in the
// matrix an area of size 2 x 2 with a maximal sum of its elements. The first line in the input 
// file contains the size of matrix N. Each of the next N lines contain N numbers separated by space. 
// The output should be a single number in a separate text file. Example:

using System;
using System.Text;
using System.IO;

class ReadMatrixFromFile
{
    static void Main()
    {
        GetMatrixFromFile();
    }

    static void GetMatrixFromFile()
    {
        StreamReader matrixInput = new StreamReader(@"..\..\inputFile.txt");
        using (matrixInput)
        {
            int matrixSize = int.Parse(matrixInput.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                string currentLine = matrixInput.ReadLine();
                string[] numbersAsString = currentLine.Split(' ');

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = int.Parse(numbersAsString[col]);
                }
            }
            // This rest of the program is from the homework for multidimensional arrays
            // so it's not as optimized as it should, but it saved me alot of writing
            FindMaxSum(matrix, matrixSize,matrixSize);
        }
    }

    static void FindMaxSum(int[,] matrix, int n, int m)
    {
        // This finds the biggest platform
        int maxSum = int.MinValue;
        int[,] platform = new int[2, 2];
        int maxCol = 0;
        int maxRow = 0;
        for (int row = 0; row < n - 1; row++)
        {
            for (int col = 0; col < m - 1; col++)
            {
                platform = FillPlatform(matrix, row, col);
                int currentSum = SumPlatform(platform);
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
    static void PrintResult(int[,] platform, int maxSum)
    {
        // As it says it just prints the platform in the end
        Console.WriteLine("This is the largest platform: ");
        for (int row = 0; row < platform.GetLength(0); row++)
        {
            for (int col = 0; col < platform.GetLength(1); col++)
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
        for (int row = 0; row < platform.GetLength(0); row++)
        {
            for (int col = 0; col < platform.GetLength(1); col++)
            {
                sum = sum + platform[row, col];
            }
        }
        return sum;
    }
    static int[,] FillPlatform(int[,] matrix, int row, int col)
    {
        // This creates a new array with only the part of matrix we're checking now
        int[,] numArray = new int[2, 2];
        numArray[0, 0] = matrix[row, col];
        numArray[0, 1] = matrix[row, col + 1];
        numArray[1, 0] = matrix[row + 1, col];
        numArray[1, 1] = matrix[row + 1, col + 1];
        return numArray;
    }
}