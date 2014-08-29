namespace _3DTRON
{
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