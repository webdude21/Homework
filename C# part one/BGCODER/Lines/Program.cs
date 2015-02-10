namespace Lines
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var counter = 0;
            var maxCol = 0;
            var result = 0;
            var counter2 = 0;
            var maxCol2 = 0;
            var result2 = 0;
            var matrix = new int[8, 8];

            // read input
            for (var row = 0; row < 8; row++)
            {
                var number = int.Parse(Console.ReadLine());
                var temp = Convert.ToString(number, 2).PadLeft(8, '0');
                for (var col = 0; col < 8; col++)
                {
                    matrix[row, col] = int.Parse(temp[col].ToString());
                }
            }

            for (var row = 0; row < 8; row++)
            {
                for (var col = 0; col < 8; col++)
                {
                    CheckForLines(ref counter, ref maxCol, ref result, matrix, row, col);
                    CheckForLines(ref counter2, ref maxCol2, ref result2, matrix, col, row);
                }
            }

            PrintMatrix(matrix);

            if (maxCol == maxCol2)
            {
                Console.WriteLine(maxCol);
                Console.WriteLine(result + result2);
            }
            else if (maxCol > maxCol2)
            {
                Console.WriteLine(maxCol);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(maxCol2);
                Console.WriteLine(result2);
            }
        }


        private static void CheckForLines(ref int counter, ref int maxCol, ref int result, int[,] matrix, int row, int col)
        {
            if (matrix[row, col] == 1)
            {
                counter++;
            }
            else if (matrix[row, col] == 0 || col == 7)
            {
                if (counter > maxCol)
                {
                    maxCol = counter;
                    result = 1;
                }

                if (counter == maxCol && matrix[row, col] != 0)
                {
                    result += 1;
                }
                counter = 0;
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (var row = 0; row < 8; row++)
            {
                for (var col = 0; col < 8; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}