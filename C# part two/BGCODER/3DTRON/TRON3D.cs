namespace _3DTRON
{
    using System;
    using System.IO;

    internal class TRON3D
    {
        public static bool[,] gameField;

        private static void Main()
        {
            if (File.Exists(@"..\..\input.txt"))
            {
                Console.SetIn(new StreamReader(@"..\..\input.txt"));
            }

            var inputDimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var startX = int.Parse(inputDimensions[0]) + 1;
            var startZ = int.Parse(inputDimensions[1]) + 1;
            var startY = int.Parse(inputDimensions[2]) + 1;

            var redMoves = Console.ReadLine();
            var blueMoves = Console.ReadLine();

            var Red = new Player(startX / 2 + startZ, startY / 2 + 1, redMoves, 'R');
            var Blue = new Player(startX / 2 + 2 * startZ, startY / 2 + 1, blueMoves, 'L');

            // може да има проблем с y заради допълнителните редове в полето
            startX = 2 * startX + 2 * startZ; // трансформираме игралното поле в 2D

            gameField = new bool[startX, startY + 2];

            // допалнителна граница която ще ни казва ако сме преминали в забранена територия
            for (var row = 0; row < gameField.GetLength(0); row++)
            {
                gameField[row, gameField.GetLength(1) - 1] = true;
                gameField[row, 0] = true;
            }

            for (var cycle = 0; cycle < redMoves.Length; cycle++)
            {
                if (Red.LostGame || Blue.LostGame)
                {
                    break;
                }

                Red.Move(cycle);
                Blue.Move(cycle);
            }

            if (Red.LostGame && Blue.LostGame)
            {
                Console.WriteLine("DRAW");
            }
            else if (Red.LostGame)
            {
                Console.WriteLine("BLUE");
            }
            else if (Blue.LostGame)
            {
                Console.WriteLine("RED");
            }

            var distanceX = Math.Abs(Red.x - (startX / 2));
            var distanceY = Math.Abs(Blue.y - (startY / 2));
            if (distanceY > gameField.GetLength(1) / 2)
            {
                distanceY = gameField.GetLength(1) - distanceY;
            }

            Console.WriteLine(distanceX + distanceY);
        }
    }

    internal class Player
    {
        private char currentDirection;

        public Player(int x, int y, string directions, char initialDirection)
        {
            this.x = x;
            this.y = y;
            this.Directions = directions;
            this.currentDirection = initialDirection;
        }

        public int x { get; set; }

        public int y { get; set; }

        public bool LostGame { get; set; }

        public string Directions { get; set; }

        public int Travel { get; set; }

        public char CurrentDirection
        {
            get
            {
                return this.currentDirection;
            }

            set
            {
                if (value == 'L')
                {
                    switch (this.currentDirection)
                    {
                        case 'D':
                            this.currentDirection = 'R';
                            break;
                        case 'U':
                            this.currentDirection = 'L';
                            break;
                        case 'R':
                            this.currentDirection = 'U';
                            break;
                        case 'L':
                            this.currentDirection = 'D';
                            break;
                    }
                }
                else if (value == 'R')
                {
                    switch (this.currentDirection)
                    {
                        case 'D':
                            this.currentDirection = 'L';
                            break;
                        case 'U':
                            this.currentDirection = 'R';
                            break;
                        case 'R':
                            this.currentDirection = 'D';
                            break;
                        case 'L':
                            this.currentDirection = 'U';
                            break;
                    }
                }
            }
        }

        public void Move(int cycle)
        {
            if (this.Directions[cycle] == 'M')
            {
                switch (this.currentDirection)
                {
                    case 'D':
                        this.y = this.y - 1;
                        break;
                    case 'U':
                        this.y = this.y + 1;
                        break;
                    case 'R':
                        this.x = this.x + 1;
                        break;
                    case 'L':
                        this.x = this.x - 1;
                        break;
                }

                this.WarpIfNeeded();
                if (TRON3D.gameField[this.x, this.y])
                {
                    this.LostGame = true;
                }
                else
                {
                    this.Travel++;
                    TRON3D.gameField[this.x, this.y] = true;

                    // може да има проблем с y заради допълнителните редове в полето
                }
            }
            else
            {
                this.CurrentDirection = this.Directions[cycle];
            }
        }

        private void WarpIfNeeded()
        {
            if (this.x >= TRON3D.gameField.GetLength(0))
            {
                this.x = 0;
            }
            else if (this.x < 0)
            {
                this.x = TRON3D.gameField.GetLength(0) - 1;
            }
        }
    }
}