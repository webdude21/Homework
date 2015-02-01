namespace UK_Flag
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var matrix = new string[number, number];
            byte diagonalRow = 0;
            byte diagonalCol = 0;
            byte verticalRow = 0;
            var verticalCol = number / 2;
            byte diagonalRow2 = 0;
            var diagonalCol2 = number - 1;
            var lineRow = number / 2;
            byte linecol = 0;

            for (var row = 0; row < number; row++)
            {
                for (var col = 0; col < number; col++)
                {
                    matrix[row, col] = ".";
                    matrix[diagonalRow, diagonalCol] = "\\";
                    matrix[verticalRow, verticalCol] = "|";
                    matrix[diagonalRow2, diagonalCol2] = "/";
                }

                diagonalCol++;
                diagonalRow++;
                verticalRow++;
                diagonalCol2--;
                diagonalRow2++;
            }

            for (var row = 0; row < number; row++)
            {
                for (var col = 0; col < number; col++)
                {
                    matrix[lineRow, linecol] = "-";
                }

                linecol++;
            }

            matrix[number / 2, number / 2] = "*";
            for (var row = 0; row < number; row++)
            {
                for (var col = 0; col < number; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}