namespace BishopFinder
{
    using System;

    internal class Program
    {
        private static ulong sum;
        private static void Main(string[] args)
        {
            var firstLineOfInput = Console.ReadLine().Split();
            var rowMax = int.Parse(firstLineOfInput[0]);
            var colMax = int.Parse(firstLineOfInput[1]);
            var moves = int.Parse(Console.ReadLine());
            var chessBoard = GenerateChessBoard(rowMax, colMax);

            var currentPos = new Tuple<int, int>(rowMax - 1, 0);

            for (var currentMove = 0; currentMove < moves; currentMove++)
            {
                var instructuion = Console.ReadLine().Split();
                currentPos = MakeNextStep(currentPos.Item1, currentPos.Item2, instructuion[0], int.Parse(instructuion[1]), chessBoard);
            }

            sum += chessBoard[currentPos.Item1, currentPos.Item2];

            Console.WriteLine(sum);
        }


        private static Tuple<int, int> MakeNextStep(int curRow, int curCol, string instruction, int moves, ulong[,] chessBoard)
        {
            var nextRow = curRow;
            var nextCol = curCol;
            moves--;

            switch (instruction.ToUpper())
            {
                case "DR":
                case "RD":
                    for (var i = 0; i < moves; i++)
                    {
                        sum += chessBoard[nextRow, nextCol];
                        chessBoard[nextRow, nextCol] = 0;

                        var isOutside = CheckIfOutsideTheBoard(nextRow + 1, nextCol + 1, chessBoard);
                        if (isOutside)
                        {
                            return new Tuple<int, int>(nextRow--, nextCol--);
                        }
                        nextCol++;
                        nextRow++;
                    }
                    break;
                case "UR":
                case "RU":
                    for (var i = 0; i < moves; i++)
                    {
                        sum += chessBoard[nextRow, nextCol];
                        chessBoard[nextRow, nextCol] = 0;
                        var isOutside = CheckIfOutsideTheBoard(nextRow - 1, nextCol + 1, chessBoard);
                        if (isOutside)
                        {
                            return new Tuple<int, int>(nextRow++, nextCol--);
                        }
          
                        nextRow--;
                        nextCol++;
                    }
                    break;
                case "UL":
                case "LU":
                    for (var i = 0; i < moves; i++)
                    {
                        sum += chessBoard[nextRow, nextCol];
                        chessBoard[nextRow, nextCol] = 0;
                        var isOutside = CheckIfOutsideTheBoard(nextRow - 1, nextCol - 1, chessBoard);
                        if (isOutside)
                        {
                            return new Tuple<int, int>(nextRow++, nextCol++);
                        }
                 
                        nextRow--;
                        nextCol--;
                    }
                    break;
                case "DL":
                case "LD":
                    for (var i = 0; i < moves; i++)
                    {
                        sum += chessBoard[nextRow, nextCol];
                        chessBoard[nextRow, nextCol] = 0;
                        var isOutside = CheckIfOutsideTheBoard(nextRow + 1, nextCol - 1, chessBoard);
                        if (isOutside)
                        {
                            return new Tuple<int, int>(nextRow--, nextCol++);
                        }
                    
                        nextRow++;
                        nextCol--;
                    }
                    break;
            }

            return new Tuple<int, int>(nextRow, nextCol);
        }

        private static bool CheckIfOutsideTheBoard(int nextRow, int nextCol, ulong[,] chessBoard)
        {
            return nextRow >= chessBoard.GetLength(0) || nextCol >= chessBoard.GetLength(1) || nextCol < 0
                   || nextRow < 0;
        }

        private static ulong[,] GenerateChessBoard(int rowMax, int colMax)
        {
            var chessBoard = new ulong[rowMax, colMax];
            var currentDigit = 0;

            for (var row = rowMax - 1; row >= 0; row--)
            {
                for (var col = 0; col < colMax; col++)
                {
                    chessBoard[row, col] = (ulong)((col + currentDigit) * 3);
                }

                currentDigit++;
            }

            return chessBoard;
        }

    }
}