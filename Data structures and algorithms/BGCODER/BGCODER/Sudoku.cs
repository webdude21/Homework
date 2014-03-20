using System;
using System.IO;

namespace BGCODER
{
    class Sudoku
    {
        private static int[,] sudokuInput;
        private const int SudokuSize = 9;
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
        }
    }
}
