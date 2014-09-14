namespace TicTacToe
{
    using System;

    internal class TicTacToe
    {
        private const int Size = 3;

        private const char Unused = '-';

        private const char PlayerOne = 'X';

        private const char PlayerTwo = 'O';

        private static char[][] grid;

        private static int playerOneWins;

        private static int playerTwoWins;

        private static int drawGames;

        private static bool playerOneTurn = true;

        private static void Main()
        {
            ReadInput();
            CheckWhosTurnItIs();
            Solve();
            Console.WriteLine(playerOneWins);
            Console.WriteLine(drawGames);
            Console.WriteLine(playerTwoWins);
        }

        private static void CheckWhosTurnItIs()
        {
            var playerOneTicks = 0;
            var playerTwoTicks = 0;

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (grid[i][j] == PlayerOne)
                    {
                        playerOneTicks++;
                    }

                    if (grid[i][j] == PlayerTwo)
                    {
                        playerTwoTicks++;
                    }
                }
            }

            if (playerOneTicks > playerTwoTicks)
            {
                playerOneTurn = false;
            }
        }

        private static void Solve()
        {
            if (CheckForWinner())
            {
                return;
            }

            if (CheckDraw())
            {
                drawGames++;
                return;
            }

            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (grid[i][j] == Unused)
                    {
                        PlayTurn(i, j);
                        Solve();
                        grid[i][j] = Unused;
                        playerOneTurn = !playerOneTurn;
                    }
                }
            }
        }

        private static void PlayTurn(int row, int col)
        {
            if (playerOneTurn)
            {
                grid[row][col] = PlayerOne;
                playerOneTurn = false;
            }
            else
            {
                grid[row][col] = PlayerTwo;
                playerOneTurn = true;
            }
        }

        private static bool CheckForWinner()
        {
            if (CheckIfWinner(PlayerOne))
            {
                playerOneWins++;
                return true;
            }

            if (CheckIfWinner(PlayerTwo))
            {
                playerTwoWins++;
                return true;
            }

            return false;
        }

        private static bool CheckIfWinner(char player)
        {
            if (grid[2][0] == player && grid[1][1] == player && grid[0][2] == player)
            {
                return true;
            }

            if (grid[0][0] == player && grid[1][1] == player && grid[2][2] == player)
            {
                return true;
            }

            for (var i = 0; i < Size; i++)
            {
                if (grid[i][0] == player && grid[i][1] == player && grid[i][2] == player)
                {
                    return true;
                }

                if (grid[0][i] == player && grid[1][i] == player && grid[2][i] == player)
                {
                    return true;
                }
            }

            return false;
        }

        private static void ReadInput()
        {
            grid = new char[Size][];

            for (var i = 0; i < Size; i++)
            {
                grid[i] = Console.ReadLine().ToCharArray();
            }
        }

        private static bool CheckDraw()
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (grid[i][j] == Unused)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}