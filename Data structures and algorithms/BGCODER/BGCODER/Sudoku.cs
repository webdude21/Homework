using System;

namespace BGCODER
{
    internal class Sudoku
    {
        private const int GridSize = 9;

        private const int TileSize = 3;

        private static readonly int[,] Grid = new int[GridSize, GridSize];

        private static void Main()
        {
            var firstRow = GridSize;
            var firstCol = GridSize;
            ReadInput(ref firstRow, ref firstCol);
            Solve(firstRow, firstCol);
            PrintResultOnConsole();
        }

        private static void PrintResultOnConsole()
        {
            for (var row = 0; row < GridSize; row++)
            {
                for (var col = 0; col < GridSize; col++)
                {
                    Console.Write(Grid[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void ReadInput(ref int firstRow, ref int firstCol)
        {
            for (var row = 0; row < GridSize; row++)
            {
                var line = Console.ReadLine();
                for (var col = 0; col < GridSize; col++)
                {
                    if (line[col] - '0' > 0 && line[col] - '0' < 10)
                    {
                        Grid[row, col] = line[col] - '0';
                    }
                    else
                    {
                        if (firstRow >= row && firstCol > col)
                        {
                            firstRow = row;
                            firstCol = col;
                        }
                    }
                }
            }
        }

        private static bool Solve(int row, int col)
        {
            var usedDigits = GetUsedDigits(row, col);
            for (var digit = 1; digit < GridSize + 1; digit++)
            {
                if (!usedDigits[digit - 1])
                {
                    Grid[row, col] = digit;
                    var nextRow = row;
                    var nextCol = col;
                    GetNextCell(ref nextRow, ref nextCol);
                    if (nextRow == GridSize)
                    {
                        return true;
                    }

                    if (Solve(nextRow, nextCol))
                    {
                        return true;
                    }
                }
            }

            Grid[row, col] = 0;
            return false;
        }

        private static void GetNextCell(ref int nextRow, ref int nextCol)
        {
            while (nextRow < GridSize && Grid[nextRow, nextCol] > 0)
            {
                if (++nextCol > 8)
                {
                    nextCol = 0;
                    nextRow++;
                }
            }
        }

        private static bool[] GetUsedDigits(int row, int col)
        {
            var usedDigits = new bool[GridSize];
            for (var index = 0; index < GridSize; index++)
            {
                if (Grid[row, index] > 0)
                {
                    usedDigits[Grid[row, index] - 1] = true;
                }

                if (Grid[index, col] > 0)
                {
                    usedDigits[Grid[index, col] - 1] = true;
                }

                if (Grid[(row / TileSize) * TileSize + index / TileSize, (col / TileSize) * TileSize + index % TileSize] > 0)
                {
                    usedDigits[Grid[(row / TileSize) * TileSize + index / TileSize, (col / TileSize) * TileSize + index % TileSize] - 1] = true;
                }
            }

            return usedDigits;
        }
    }
}