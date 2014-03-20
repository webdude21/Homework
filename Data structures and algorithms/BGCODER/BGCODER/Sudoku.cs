using System;
using System.IO;
using System.Security.Cryptography;

namespace BGCODER
{
    class Sudoku
    {
        private static int[,] sudokuInput;
        private const int SudokuSize = 9;
        private static Random randomGen = new Random();

        static void Main()
        {
            Console.SetIn(new StreamReader(@"../../input.txt"));
            sudokuInput = new int[SudokuSize, SudokuSize];

            for (var i = 0; i < SudokuSize; i++)
            {
                var charArray = Console.ReadLine().ToCharArray();
                for (var j = 0; j < SudokuSize; j++)
                {
                    if (charArray[j] - '0' < 10 && charArray[j] - '0' > 0)
                    {
                        sudokuInput[i, j] = charArray[j] - '0';
                    }
                }
            }

            Solve(0, 3);
        }

        public static void Solve(int startPosition, int tileSize)
        {
            var currentTile = new int[tileSize, tileSize];
            var numberUsed = new bool[tileSize * tileSize];

            for (var row = startPosition; row < tileSize; row++)
            {
                for (var col = startPosition; col < tileSize; col++)
                {
                    if (currentTile[row, col] != 0)
                    {
                        currentTile[row, col] = sudokuInput[row, col];
                        numberUsed[currentTile[row, col]] = true;
                    }
                }
            }
        }

        public bool CheckIfSolved(int[,] testSolution)
        {
            for (var row = 0; row < SudokuSize; row++)
            {
                var check = new bool[SudokuSize];
                for (var col = 0; col < SudokuSize; col++)
                {
                    if (check[testSolution[row, col]])
                    {
                        return false;
                    }
                    check[testSolution[row, col]] = true;
                }
            }

            return true;
        }

        public int GetRandomNumber { get; set; }
    }
}
