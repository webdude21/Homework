using System;
using System.IO;

class TRON3D
{
    public static bool[,] gameField;
    static void Main()
    {
        if (File.Exists(@"..\..\input.txt"))
        {
            Console.SetIn(new StreamReader(@"..\..\input.txt"));
        }

        string[] inputDimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int startX = int.Parse(inputDimensions[0]) + 1;
        int startZ = int.Parse(inputDimensions[1]) + 1;
        int startY = int.Parse(inputDimensions[2]) + 1;

        string redMoves = Console.ReadLine();
        string blueMoves = Console.ReadLine();

        Player Red = new Player(startX / 2 + startZ, startY / 2 + 1, redMoves, 'R');
        Player Blue = new Player(startX / 2 + 2 * startZ, startY / 2 + 1, blueMoves, 'L'); // може да има проблем с y заради допълнителните редове в полето

        startX = 2 * startX + 2 * startZ; // трансформираме игралното поле в 2D

        gameField = new bool[startX, startY + 2]; // допалнителна граница която ще ни казва ако сме преминали в забранена територия

        for (int row = 0; row < gameField.GetLength(0); row++)
        {
            gameField[row, gameField.GetLength(1) - 1] = true;
            gameField[row, 0] = true;
        }

        for (int cycle = 0; cycle < redMoves.Length; cycle++)
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

        int distanceX = Math.Abs(Red.x - (startX / 2));
        int distanceY = Math.Abs(Blue.y - (startY / 2));
        if (distanceY > gameField.GetLength(1) / 2)
        {
            distanceY = gameField.GetLength(1) - distanceY;
        }
        Console.WriteLine(distanceX + distanceY);
    }

}

class Player
{
    public int x { get; set; }
    public int y { get; set; }
    public bool LostGame { get; set; }
    public string Directions { get; set; }
    public int Travel { get; set; }

    private char currentDirection;
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
    public Player(int x, int y, string directions, char initialDirection)
    {
        this.x = x;
        this.y = y;
        this.Directions = directions;
        this.currentDirection = initialDirection;
    }

    public void Move(int cycle)
    {
        if (Directions[cycle] == 'M')
        {
            switch (currentDirection)
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

            WarpIfNeeded();
            if (TRON3D.gameField[this.x, this.y])
            {
                this.LostGame = true;
            }
            else
            {
                Travel++;
                TRON3D.gameField[this.x, this.y] = true;// може да има проблем с y заради допълнителните редове в полето
            }

        }
        else
        {
            CurrentDirection = Directions[cycle];
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
