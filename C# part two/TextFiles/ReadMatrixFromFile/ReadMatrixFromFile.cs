// Write a program that reads a text file containing a square matrix of numbers and finds in the
// matrix an area of size 2 x 2 with a maximal sum of its elements. The first line in the input 
// file contains the size of matrix N. Each of the next N lines contain N numbers separated by space. 
// The output should be a single number in a separate text file. Example:
namespace ReadMatrixFromFile
{
    using System;
    using System.IO;

    internal class ReadMatrixFromFile
    {
        private static void Main()
        {
            GetMatrixFromFile();
        }

        private static void GetMatrixFromFile()
        {
            var matrixInput = new StreamReader(@"..\..\inputFile.txt");
            using (matrixInput)
            {
                var matrixSize = int.Parse(matrixInput.ReadLine());
                var matrix = new int[matrixSize, matrixSize];

                for (var row = 0; row < matrixSize; row++)
                {
                    var currentLine = matrixInput.ReadLine();
                    var numbersAsString = currentLine.Split(' ');

                    for (var col = 0; col < matrixSize; col++)
                    {
                        matrix[row, col] = int.Parse(numbersAsString[col]);
                    }
                }

                // This rest of the program is from the homework for multidimensional arrays
                // so it's not as optimized as it should, but it saved me alot of writing
                FindMaxSum(matrix, matrixSize, matrixSize);
            }
        }

        private static void FindMaxSum(int[,] matrix, int n, int m)
        {
            // This finds the biggest platform
            var maxSum = int.MinValue;
            var platform = new int[2, 2];
            var maxCol = 0;
            var maxRow = 0;
            for (var row = 0; row < n - 1; row++)
            {
                for (var col = 0; col < m - 1; col++)
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
            for (var row = 0; row < platform.GetLength(0); row++)
            {
                for (var col = 0; col < platform.GetLength(1); col++)
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
            for (var row = 0; row < platform.GetLength(0); row++)
            {
                for (var col = 0; col < platform.GetLength(1); col++)
                {
                    sum = sum + platform[row, col];
                }
            }

            return sum;
        }

        private static int[,] FillPlatform(int[,] matrix, int row, int col)
        {
            // This creates a new array with only the part of matrix we're checking now
            var numArray = new int[2, 2];
            numArray[0, 0] = matrix[row, col];
            numArray[0, 1] = matrix[row, col + 1];
            numArray[1, 0] = matrix[row + 1, col];
            numArray[1, 1] = matrix[row + 1, col + 1];
            return numArray;
        }
    }
}