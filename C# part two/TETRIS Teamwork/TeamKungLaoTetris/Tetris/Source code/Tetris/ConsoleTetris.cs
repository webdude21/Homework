using System;
using System.Threading;

namespace Tetris
{
    class ConsoleTetris
    {
        public static Block bigBlock;
        public static Block[] brickPlayer = new Block[2];
        public static int score = 0;
        public static int level = 1;
        public static int millisecond;
        public static int countPrint = 0;
        public static Block nextBrick;
        public static int linesCleared = 0;
        public static int[] playerPos = { 4, 10 };
        public static int numberOfPlayers = 0;

        static void ResetTetris()
        {
            Main();
        }
        static void PrintStatus()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            PrintOnPosition(34, 1, string.Format("Score: {0, 7}", score));
            PrintOnPosition(34, 3, string.Format("Level: {0, 7}", level));
            PrintOnPosition(34, 5, string.Format("Lines: {0, 7}", linesCleared));
            PrintOnPosition(34, 7, "R (Reset)");
            PrintOnPosition(34, 9, "P (Pause)");
            PrintOnPosition(34, 11, "M (Music on/off)");
            PrintOnPosition(34, 13, "F (FX on/off)");
            PrintOnPosition(34, 15, "N (No sound)");
            PrintOnPosition(34, 18, "|");
            PrintOnPosition(48, 18, "|");
            PrintOnPosition(34, 19, "|");
            PrintOnPosition(48, 19, "|");
            PrintOnPosition(34, 19, "|");
            PrintOnPosition(48, 19, "|");
            PrintOnPosition(34, 20, "|");
            PrintOnPosition(48, 20, "|");
            PrintOnPosition(34, 21, "|");
            PrintOnPosition(48, 21, "|");
            PrintOnPosition(34, 22, "|");
            PrintOnPosition(48, 22, "|");
            PrintOnPosition(35, 17, "-------------");
            PrintOnPosition(35, 23, "-------------");
        }
        public static void PrintOnPosition(int x, int y, string s, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(s);
        }
        static void Left(int playerNumber)
        {
            brickPlayer[playerNumber].blockPositionX--;

            if ((numberOfPlayers == 1 && Block.OverlapBlocks(brickPlayer[playerNumber], bigBlock)) ||
                (numberOfPlayers == 2 && Block.OverlapBlocks(brickPlayer[1], brickPlayer[0], bigBlock)))
            {
                brickPlayer[playerNumber].blockPositionX++;
            }
            else
            {
                brickPlayer[playerNumber].blockPositionX++;
                brickPlayer[playerNumber].Clear();
                brickPlayer[playerNumber].blockPositionX--;
                brickPlayer[playerNumber].Print();
                Sounds.SFX(Sounds.SoundEffects.Move);
            }
        }
        static void Right(int playerNumber)
        {
            brickPlayer[playerNumber].blockPositionX++;

            if ((numberOfPlayers == 1 && Block.OverlapBlocks(brickPlayer[playerNumber], bigBlock)) ||
                (numberOfPlayers == 2 && Block.OverlapBlocks(brickPlayer[1], brickPlayer[0], bigBlock)))
            {
                brickPlayer[playerNumber].blockPositionX--;
            }
            else
            {
                brickPlayer[playerNumber].blockPositionX--;
                brickPlayer[playerNumber].Clear();
                brickPlayer[playerNumber].blockPositionX++;
                brickPlayer[playerNumber].Print();
                Sounds.SFX(Sounds.SoundEffects.Move);
            }
        }
        static void Down(int playerNumber)
        {
            brickPlayer[playerNumber].blockPositionY++;

            if (numberOfPlayers == 2 && Block.OverlapBlocks(brickPlayer[1], brickPlayer[0]))
            {
                brickPlayer[playerNumber].blockPositionY--;
            }
            else if (Block.OverlapBlocks(brickPlayer[playerNumber], bigBlock))
            {
                brickPlayer[playerNumber].blockPositionY--;
                bigBlock = bigBlock + brickPlayer[playerNumber];
                brickPlayer[playerNumber] = nextBrick.Clone();
                brickPlayer[playerNumber].blockPositionX = playerPos[playerNumber];
                brickPlayer[playerNumber].Print();
                CheckForCompleteLines();
                nextBrick = GenerateRandomBlock(playerPos[playerNumber]);
                PrintNextBrick();
                bigBlock.SetColor(15);
                bigBlock.Print();
            }
            else
            {
                brickPlayer[playerNumber].blockPositionY--;
                brickPlayer[playerNumber].Clear();
                Sounds.SFX(Sounds.SoundEffects.Move);
                brickPlayer[playerNumber].blockPositionY++;
                brickPlayer[playerNumber].Print();
            }
        }
        static void Drop(int playerNumber)
        {

            if (numberOfPlayers == 2)
            {
                if (brickPlayer[playerNumber].blockPositionY > brickPlayer[Math.Abs(playerNumber - 1)].blockPositionY)
                {
                    while (Block.OverlapBlocks(brickPlayer[playerNumber], bigBlock) == false)
                    {
                        score += level * 2; // Bonus score
                        brickPlayer[playerNumber].blockPositionY++;
                        if (Block.OverlapBlocks(brickPlayer[playerNumber], bigBlock) == true)
                        {
                            brickPlayer[playerNumber].blockPositionY--;
                            bigBlock = bigBlock + brickPlayer[playerNumber];
                            brickPlayer[playerNumber] = nextBrick;
                            brickPlayer[playerNumber].blockPositionX = playerPos[playerNumber];
                            brickPlayer[playerNumber].Print();
                            CheckForCompleteLines();
                            nextBrick = GenerateRandomBlock(playerPos[0]);
                            Sounds.SFX(Sounds.SoundEffects.Drop);
                            PrintNextBrick();
                            bigBlock.SetColor(15);
                            bigBlock.Print();
                            return;
                        }
                        else
                        {
                            brickPlayer[playerNumber].blockPositionY--;
                            brickPlayer[playerNumber].Clear();
                            brickPlayer[playerNumber].blockPositionY++;
                            brickPlayer[playerNumber].Print();
                        }
                    }
                }
                else if (brickPlayer[playerNumber].blockPositionX > brickPlayer[Math.Abs(playerNumber - 1)].blockPositionX + brickPlayer[Math.Abs(playerNumber - 1)].blockCols - 1 || brickPlayer[playerNumber].blockPositionX + brickPlayer[playerNumber].blockCols - 1 < brickPlayer[Math.Abs(playerNumber - 1)].blockPositionX)
                    while (Block.OverlapBlocks(brickPlayer[playerNumber], bigBlock) == false)
                    {
                        score += level * 2; // Bonus score
                        brickPlayer[playerNumber].blockPositionY++;
                        if (Block.OverlapBlocks(brickPlayer[playerNumber], bigBlock) == true)
                        {
                            brickPlayer[playerNumber].blockPositionY--;
                            bigBlock = bigBlock + brickPlayer[playerNumber];
                            brickPlayer[playerNumber] = nextBrick;
                            brickPlayer[playerNumber].blockPositionX = playerPos[playerNumber];
                            brickPlayer[playerNumber].Print();
                            CheckForCompleteLines();
                            nextBrick = GenerateRandomBlock(playerPos[0]);
                            Sounds.SFX(Sounds.SoundEffects.Drop);
                            PrintNextBrick();
                            bigBlock.SetColor(15);
                            bigBlock.Print();
                            return;
                        }
                        else
                        {
                            brickPlayer[playerNumber].blockPositionY--;
                            brickPlayer[playerNumber].Clear();
                            brickPlayer[playerNumber].blockPositionY++;
                            brickPlayer[playerNumber].Print();
                        }
                    }
            }
            else
            {
                while (Block.OverlapBlocks(brickPlayer[playerNumber], bigBlock) == false)
                {
                    score += level * 2; // Bonus score
                    brickPlayer[playerNumber].blockPositionY++;
                    if (Block.OverlapBlocks(brickPlayer[playerNumber], bigBlock) == true)
                    {
                        brickPlayer[playerNumber].blockPositionY--;
                        bigBlock = bigBlock + brickPlayer[playerNumber];
                        brickPlayer[playerNumber] = nextBrick;
                        brickPlayer[playerNumber].blockPositionX = playerPos[playerNumber];
                        brickPlayer[playerNumber].Print();
                        CheckForCompleteLines();
                        nextBrick = GenerateRandomBlock(playerPos[0]);
                        Sounds.SFX(Sounds.SoundEffects.Drop);
                        PrintNextBrick();
                        bigBlock.SetColor(15);
                        bigBlock.Print();
                        return;
                    }
                    else
                    {
                        brickPlayer[playerNumber].blockPositionY--;
                        brickPlayer[playerNumber].Clear();
                        brickPlayer[playerNumber].blockPositionY++;
                        brickPlayer[playerNumber].Print();
                    }
                }
            }
        }
        static Block Rotate(Block inp)
        {
            if (inp.blockCols != inp.blockRows) // If it's The O-Tetrimino there's no sence in rotating it
            {
                inp.Clear();
                Block newBlock = inp.Rotate();

                if (Block.OverlapBlocks(newBlock, bigBlock))
                {
                    inp.Print();
                    return inp;
                }
                else
                {
                    newBlock.Print();
                    Sounds.SFX(Sounds.SoundEffects.Rotate);
                    return newBlock;
                }
            }
            return inp;
        }
        static void Gameover(Block inp)
        {
            if (Block.OverlapBlocks(inp, bigBlock) == true)
            {
                if (bigBlock.blockRows == Console.WindowHeight)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Sounds.SFX(Sounds.SoundEffects.GameOver);
                    PrintOnPosition(12, 12, "Game Over!");
                    Thread.Sleep(2000);
                    Main();
                }
            }
        }
        static void KeyboardReading()
        {
            while (Console.KeyAvailable)
            {
                Console.SetCursorPosition(34, 0);
                Console.ForegroundColor = (ConsoleColor)0;
                Console.BackgroundColor = (ConsoleColor)0;
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Escape:
                        Console.BackgroundColor = (ConsoleColor)0;
                        Console.ForegroundColor = (ConsoleColor)15;
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.LeftArrow:
                        if (numberOfPlayers == 1) Left(0);
                        if (numberOfPlayers == 2) Left(1);
                        break;
                    case ConsoleKey.A:
                        if (numberOfPlayers == 2) Left(0);
                        break;
                    case ConsoleKey.RightArrow:
                        if (numberOfPlayers == 1) Right(0);
                        if (numberOfPlayers == 2) Right(1);
                        break;
                    case ConsoleKey.D:
                        if (numberOfPlayers == 2) Right(0);
                        break;
                    case ConsoleKey.F:
                        Sounds.SfxON = !Sounds.SfxON;
                        break;
                    case ConsoleKey.N:
                        Sounds.SfxON = false;
                        Sounds.MusicOn = false;
                        break;
                    case ConsoleKey.DownArrow:
                        if (numberOfPlayers == 1) Down(0);
                        if (numberOfPlayers == 2) Down(1);
                        score += level * 2;  // Bonus score
                        break;
                    case ConsoleKey.S:
                        if (numberOfPlayers == 2) Down(0);
                        score += level * 2; // Bonus score
                        break;
                    case ConsoleKey.Spacebar:
                        if (numberOfPlayers == 1) Drop(0);
                        if (numberOfPlayers == 2) Drop(1);
                        break;
                    case ConsoleKey.Tab:
                        if (numberOfPlayers == 2) Drop(0);
                        break;
                    case ConsoleKey.R:
                        ResetTetris();
                        break;
                    case ConsoleKey.P:
                        Console.ReadKey();
                        break;
                    case ConsoleKey.UpArrow:
                        if (numberOfPlayers == 1) brickPlayer[0] = Rotate(brickPlayer[0]);
                        if (numberOfPlayers == 2) brickPlayer[1] = Rotate(brickPlayer[1]);
                        break;
                    case ConsoleKey.W:
                        if (numberOfPlayers == 2) brickPlayer[0] = Rotate(brickPlayer[0]);
                        break;
                    case ConsoleKey.M:
                        Sounds.MusicOn = !Sounds.MusicOn;
                        break;
                    default:
                        break;
                }
            }
        }
        static bool Delay(int level)
        {
            int millisecondNow = DateTime.Now.Millisecond;
            int delay = (21 - level) * 26;

            if (millisecondNow > millisecond)
            {
                if (millisecondNow - millisecond > delay)
                {
                    millisecond = millisecondNow;
                    return false;
                }
            }
            else
                if (millisecondNow - millisecond + 1000 > delay)
                {
                    millisecond = millisecondNow;
                    return false;
                }
            return true;
        }
        public static Block GenerateRandomBlock(int player)
        {
            string[] randomColor = { "Gray", "Blue", "Green", "Cyan", "Red", "Magenta", "Yellow",
        "DarkBlue","DarkGreen","DarkMagenta","DarkCyan","DarkRed","DarkYellow"}; // Colors allowed to be used
            Random randomGen = new Random(); // new random instance
            int pos = player;
            int color = (int)Enum.Parse(typeof(ConsoleColor), randomColor[randomGen.Next(0, 13)]); // pick random color from the array
            int pieceType = randomGen.Next(0, 7); // generate random piece
            // Theese are the official Tetris block types
            switch (pieceType)
            {
                case 0:
                    return new Block(pos, 0, new int[,] { { color, color }, { color, color } }); // The O-Tetrimino
                case 1:
                    return new Block(pos, 0, new int[,] { { color, 0, 0 }, { color, color, color } }); // The J-Tetrimino
                case 2:
                    return new Block(pos, 0, new int[,] { { 0, 0, color }, { color, color, color } }); // The L-Tetrimino
                case 3:
                    return new Block(pos, 0, new int[,] { { 0, color, color }, { color, color, 0 } }); // The S-Tetrimino
                case 4:
                    return new Block(pos, 0, new int[,] { { color, color, 0 }, { 0, color, color } }); // The Z-Tetrimino
                case 5:
                    return new Block(pos, 0, new int[,] { { color, color, color, color } }); // The I-Tetrimino
                case 6:
                    return new Block(pos, 0, new int[,] { { 0, color, 0 }, { color, color, color } }); // The T-Tetrimino
                default:
                    return new Block(pos, 0, new int[,] { { 0, color, 0 }, { color, color, color } }); // The T-Tetrimino is default
            }
        }
        static void PrintNextBrick()
        {
            if (countPrint == 10)
            {
                score += 100 * level; //bonus score
                countPrint = 0;
            }
            score += 17 * level;
            countPrint++;

            const int nextBrickX = 20;
            const int nextBrickY = 19;

            // Clear space for next Brick

            for (int y = 18; y < 23; y++)
            {
                for (int x = 35; x < 46; x++)
                {
                    Console.BackgroundColor = (ConsoleColor)0;
                    Console.SetCursorPosition(x, y);
                    Console.Write("  ");
                }
            }
            Gameover(brickPlayer[0]);
            if (numberOfPlayers == 2) Gameover(brickPlayer[1]);

            nextBrick.Print(nextBrickX, nextBrickY);
            millisecond = DateTime.Now.Millisecond;
        }
        static void CheckForCompleteLines()
        {
            int counter = 0;
            int scoreTemp = 0;
            for (int row = 0; row < 24; row++)
            {
                for (int col = 1; col < 15; col++)
                {
                    if (bigBlock[col, row] != 0)
                    {
                        counter++;
                        if (counter == 14)
                        {
                            score += (100 + scoreTemp) * level;
                            scoreTemp += 50 * level;
                            ClearRow(row);
                            linesCleared++;
                            if (linesCleared % 5 == 0)
                            {
                                level++;
                            }
                        }
                    }
                    else break;
                }
                counter = 0;
            }
            scoreTemp = 0;
        }
        static void ClearRow(int row)
        {
            bigBlock.Clear();
            for (int i = row; i > 0; i--)
            {
                for (int col = 1; col < 15; col++)
                {
                    bigBlock[col, i] = bigBlock[col, i - 1];
                }
            }
            Sounds.SFX(Sounds.SoundEffects.ClearLine);
            bigBlock.Print();
        }
        static void Main()
        {
            SetInitialGameParams();
            do
            {
                if (Delay(level) == false)
                {
                    if (numberOfPlayers == 2)
                    {
                        if (brickPlayer[1].blockPositionY > brickPlayer[01].blockPositionY)
                        {
                            Down(1);
                            brickPlayer[1].Print();
                            Down(0);
                            brickPlayer[0].Print();
                            PrintStatus();
                            continue;
                        }
                        else
                        {
                            Down(0);
                            brickPlayer[0].Print();
                            Down(1);
                            brickPlayer[1].Print();
                            PrintStatus();
                            continue;
                        }
                    }
                    Down(0);
                    brickPlayer[0].Print();
                    PrintStatus();
                }
                KeyboardReading();

            } while (true);
        }
        private static void SetInitialGameParams()
        {
            score = 0;
            level = 1;
            millisecond = 0;
            countPrint = 0;
            SetGameField();
            brickPlayer[0] = GenerateRandomBlock(playerPos[0]);
            if (numberOfPlayers == 2) brickPlayer[1] = GenerateRandomBlock(playerPos[1]);
            nextBrick = GenerateRandomBlock(playerPos[0]);
            PrintNextBrick();
            brickPlayer[0].Print();
            if (numberOfPlayers == 2) brickPlayer[0].Print();
            millisecond = DateTime.Now.Millisecond;
            PrintStatus();
            Thread.Sleep(1);
        }
        private static void SetGameField()
        {
            Console.BackgroundColor = (ConsoleColor)0;
            Console.ForegroundColor = (ConsoleColor)15;
            Console.Clear();
            Console.Title = "Console Tetris";
            Console.WindowHeight = 25;
            Console.WindowWidth = 51;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
            PrintInfoScreen();

            bigBlock = new Block(0, 0, new int[16, 25]);

            for (int i = 0; i < 25; i++)
            {
                bigBlock[0, i] = 15;
                bigBlock[15, i] = 15;
            }
            for (int i = 0; i < 16; i++)
            {
                bigBlock[i, 24] = 15;
            }

            bigBlock.Print();
        }
        private static void PrintInfoScreen()
        {
            Console.Write(@"Tetris for the Dauntless 
C# Console Tetris by Kunglao Team
Controls:
      Player 1 controls:
[→]         Move Block Right
[←]         Move Block Left
[↑]         Rotate block counterclockwise
[↓]         Push Block down 1 Unit
[SPACE]     Drop Block
      Player 2 controls:
[D]         Move Block Right
[A]         Move Block Left
[W]         Rotate block counterclockwise
[S]         Push Block down 1 Unit
[TAB]       Drop Block
[C]         Change direction of block rotation

[R]         Reset           [P]         Pause
[M]         Music On/Off    [F]         FX On/Of
[N]         No sound
[ESC]       Exit Game

Press 1 for single player game!
Press 2 for multi player game!
");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    numberOfPlayers = 1;
                    playerPos[0] = 7;
                    break;
                case ConsoleKey.NumPad1:
                    numberOfPlayers = 1;
                    playerPos[0] = 7;
                    break;
                case ConsoleKey.D2:
                    numberOfPlayers = 2;
                    break;
                case ConsoleKey.NumPad2:
                    numberOfPlayers = 2;
                    break;
                default:
                    numberOfPlayers = 1;
                    break;
            }
            Console.Clear();
        }
    }
}
