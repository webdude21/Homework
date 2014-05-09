using System;
using System.Collections.Generic;
using System.Globalization;

namespace Minesweeper
{
    public class MineSweeperGame
    {
        public const string InitialMessage = "Lets play Minesweeper, Try out your luck! Command 'top' shows high scores, " +
                                             "'restart' generates new game and 'exit' quits the game";

        public const string EnterRowColumnMessage = "Please enter row and column: ";
        public const string ByeMessage = "Bye bye!";
        public const string InvalidCommandMessage = "\nError! Wrong command.\n";
        public const string DeathMessage = "Boom! You lost with {0} score.\nEnter your nickname: ";
        public const string OnWinCongratulations = "Yeah! You opened {0} squares and all your limbs are intact";
        public const string OnWinEnterName = "Write your name, hero: ";
        public const string ExitMessage = "Made in gentleman Bulgaria. Ho-ho-ho - Pardon me for my laugh.\nLike a sir.";
        public const string ScoreOpen = "\nScoreboard: ";
        public const string ScoreEntry = "{0}. {1} --> {2} squares";
        public const string ScoreEmpty = "Empty scoreboard";

        public static void Main()
        {
            string command;
            var gameField = MakeField();
            var mines = CreateMines();
            var cellsOpened = 0;
            var isGameOver = false;
            var highScore = new List<Player>(6);
            var row = 0;
            var col = 0;
            var isFirstMove = true;
            const int CellCount = 35;
            var allCellsOpened = false;

            do
            {
                if (isFirstMove)
                {
                    Console.WriteLine(InitialMessage);
                    PrintField(gameField);
                    isFirstMove = false;
                }

                Console.Write(EnterRowColumnMessage);
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(CultureInfo.InvariantCulture), out row) &&
                        int.TryParse(command[2].ToString(CultureInfo.InvariantCulture), out col) &&
                        row < gameField.GetLength(0) && col < gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintScoreBoard(highScore);
                        break;
                    case "restart":
                        gameField = MakeField();
                        mines = CreateMines();
                        PrintField(gameField);
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                MakeMove(gameField, mines, row, col);
                                cellsOpened++;
                            }

                            if (cellsOpened == CellCount)
                            {
                                allCellsOpened = true;
                            }
                            else
                            {
                                PrintField(gameField);
                            }
                        }
                        else
                        {
                            isGameOver = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (isGameOver)
                {
                    PrintField(mines);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. Daj si niknejm: ", cellsOpened);
                    var playerName = Console.ReadLine();
                    var player = new Player(playerName, cellsOpened);

                    if (highScore.Count < 5)
                    {
                        highScore.Add(player);
                    }
                    else
                    {
                        for (var i = 0; i < highScore.Count; i++)
                        {
                            if (highScore[i].Points < player.Points)
                            {
                                highScore.Insert(i, player);
                                highScore.RemoveAt(highScore.Count - 1);
                                break;
                            }
                        }
                    }

                    highScore.Sort((p1, p2) => string.Compare(p2.Name, p1.Name, StringComparison.Ordinal));
                    highScore.Sort((p1, p2) => p2.Points.CompareTo(p1.Points));
                    PrintScoreBoard(highScore);

                    gameField = MakeField();
                    mines = CreateMines();
                    cellsOpened = 0;
                    isGameOver = false;
                    isFirstMove = true;
                }

                if (allCellsOpened)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    PrintField(mines);
                    Console.WriteLine("Daj si imeto, batka: ");
                    var name = Console.ReadLine();
                    var player = new Player(name, cellsOpened);
                    highScore.Add(player);
                    PrintScoreBoard(highScore);
                    gameField = MakeField();
                    mines = CreateMines();
                    cellsOpened = 0;
                    allCellsOpened = false;
                    isFirstMove = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void PrintScoreBoard(List<Player> scoreBoard)
        {
            Console.WriteLine("\nTo4KI:");
            if (scoreBoard.Count > 0)
            {
                for (var i = 0; i < scoreBoard.Count; i++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} kutii",
                        i + 1,
                        scoreBoard[i].Name,
                        scoreBoard[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void MakeMove(char[,] field, char[,] mines, int row, int col)
        {
            var neighbourMinesCount = GetNeighbourMinesCount(mines, row, col);

            mines[row, col] = neighbourMinesCount;
            field[row, col] = neighbourMinesCount;
        }

        private static void PrintField(char[,] field)
        {
            var rows = field.GetLength(0);
            var cols = field.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (var row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);

                for (var col = 0; col < cols; col++)
                {
                    Console.Write("{0} ", field[row, col]);
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] MakeField()
        {
            var rows = 5;
            var cols = 10;

            var field = new char[rows, cols];

            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    field[row, col] = '?';
                }
            }

            return field;
        }

        private static char[,] CreateMines()
        {
            var rows = 5;
            var cols = 10;

            var field = new char[rows, cols];

            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    field[row, col] = '-';
                }
            }

            var randomNumbers = new List<int>();

            var randomGenerator = new Random();
            while (randomNumbers.Count < 15)
            {
                var randomNumber = randomGenerator.Next(50);
                if (!randomNumbers.Contains(randomNumber))
                {
                    randomNumbers.Add(randomNumber);
                }
            }

            foreach (var i2 in randomNumbers)
            {
                var row = i2 % cols;
                var col = i2 / cols;

                if (row == 0 && i2 != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                field[col, row - 1] = '*';
            }

            return field;
        }

        private static char GetNeighbourMinesCount(char[,] field, int row, int col)
        {
            var count = 0;
            var rows = field.GetLength(0);
            var cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString(CultureInfo.InvariantCulture));
        }
    }
}