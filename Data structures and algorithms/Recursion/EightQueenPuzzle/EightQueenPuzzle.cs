namespace EightQueenPuzzle
{
    using System;
    using System.Text;

    internal class EightQueenPuzzle
    {
        private const int BoardSize = 8;

        private const int FreeCell = 0;

        private const int Queen = 2000;

        private static readonly int[,] AttackablePosition = new int[BoardSize, BoardSize];

        private static int solutionCount;

        private static void Main()
        {
            Solve(0, 0);
            Console.WriteLine("{0} solutions ware found", solutionCount);
        }

        private static void Solve(int queenCount, int col)
        {
            if (queenCount == BoardSize)
            {
                PrintSolution();
                solutionCount++;
                return;
            }

            for (var row = 0; row < BoardSize; row++)
            {
                if (AttackablePosition[row, col] == FreeCell)
                {
                    UpdatePositionsWith(1, row, col);
                    Solve(queenCount + 1, col + 1);
                    UpdatePositionsWith(-1, row, col);
                }
            }
        }

        private static void UpdatePositionsWith(int updateNumber, int row, int col)
        {
            for (var index = 0; index < BoardSize; index++)
            {
                // check first diagonal after queen
                if (row + index < BoardSize && col + index < BoardSize)
                {
                    AttackablePosition[row + index, col + index] += updateNumber;
                }

                // check first diagonal before queen
                if (row - index >= 0 && col - index >= 0)
                {
                    AttackablePosition[row - index, col - index] += updateNumber;
                }

                // check second diagonal after queen
                if (row - index >= 0 && col + index < BoardSize)
                {
                    AttackablePosition[row - index, col + index] += updateNumber;
                }

                // check second diagonal before queen
                if (row + index < BoardSize && col - index >= 0)
                {
                    AttackablePosition[row + index, col - index] += updateNumber;
                }

                // Check rows and cols at the same time
                AttackablePosition[index, col] += updateNumber;
                AttackablePosition[row, index] += updateNumber;
            }

            if (updateNumber == 1)
            {
                AttackablePosition[row, col] = Queen;
            }

            if (updateNumber == -1)
            {
                AttackablePosition[row, col] = FreeCell;
            }
        }

        private static void PrintSolution()
        {
            var sb = new StringBuilder();
            for (var row = 0; row < BoardSize; row++)
            {
                for (var col = 0; col < BoardSize; col++)
                {
                    sb.Append(AttackablePosition[row, col] == Queen ? 'Q' : '-');
                }

                sb.Append(Environment.NewLine);
            }

            Console.WriteLine(sb);
        }
    }
}