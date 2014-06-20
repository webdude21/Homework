namespace RefactorMatrix
{
    using System.Text;

    public class WalkInMatrix
    {
        private readonly int[,] matrix;

        private readonly int matrixSize;

        private int col;

        private int directionX;

        private int directionY;

        private int[] directionsX;

        private int[] directionsY;

        private int number;

        private int row;

        public WalkInMatrix(int size)
        {
            this.matrix = new int[size, size];
            this.matrixSize = size;
            this.number = 1;
            this.directionX = 1;
            this.directionY = 1;
            this.row = 0;
            this.col = 0;

            this.InitializeDirections();
        }

        public int[,] GetMatrix
        {
            get
            {
                return (int[,])this.matrix.Clone();
            }
        }

        public void FillMatrix()
        {
            this.FillUntilNoDirectionsAreValid();

            while (this.FindZeroValueCoords())
            {
                this.number++;
                this.directionX = 1;
                this.directionY = 1;

                this.FillUntilNoDirectionsAreValid();
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (var i = 0; i < this.matrixSize; i++)
            {
                for (var j = 0; j < this.matrixSize; j++)
                {
                    result.AppendFormat("{0,3}", this.matrix[i, j]);
                }

                result.AppendLine();
            }

            return result.ToString();
        }

        private void InitializeDirections()
        {
            this.directionsX = new[] { 1, 1, 1, 0, -1, -1, -1, 0 };
            this.directionsY = new[] { 1, 0, -1, -1, -1, 0, 1, 1 };
        }

        private void ChangeDirection()
        {
            this.InitializeDirections();

            var cd = 0;

            for (var i = 0; i < 8; i++)
            {
                if (this.directionsX[i] == this.directionX && this.directionsY[i] == this.directionY)
                {
                    cd = i;
                    break;
                }
            }

            if (cd == 7)
            {
                this.directionX = this.directionsX[0];
                this.directionY = this.directionsY[0];
            }
            else
            {
                this.directionX = this.directionsX[cd + 1];
                this.directionY = this.directionsY[cd + 1];
            }
        }

        private bool IsMovePossible()
        {
            this.InitializeDirections();

            for (var i = 0; i < 8; i++)
            {
                if (this.row + this.directionsX[i] >= this.matrixSize || this.row + this.directionsX[i] < 0)
                {
                    this.directionsX[i] = 0;
                }

                if (this.col + this.directionsY[i] >= this.matrixSize || this.col + this.directionsY[i] < 0)
                {
                    this.directionsY[i] = 0;
                }
            }

            for (var i = 0; i < 8; i++)
            {
                if (this.matrix[this.row + this.directionsX[i], this.col + this.directionsY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private bool FindZeroValueCoords()
        {
            this.row = 0;
            this.col = 0;

            for (var i = 0; i < this.matrixSize; i++)
            {
                for (var j = 0; j < this.matrixSize; j++)
                {
                    if (this.matrix[i, j] == 0)
                    {
                        this.row = i;
                        this.col = j;
                        return true;
                    }
                }
            }

            return false;
        }

        private void FillUntilNoDirectionsAreValid()
        {
            while (true)
            {
                this.matrix[this.row, this.col] = this.number;

                if (!this.IsMovePossible())
                {
                    break;
                }

                if (this.IsCurrentDirectionBlind())
                {
                    while (this.FindValidDirection())
                    {
                        this.ChangeDirection();
                    }
                }

                this.row += this.directionX;
                this.col += this.directionY;
                this.number++;
            }
        }

        private bool IsCurrentDirectionBlind()
        {
            return this.row + this.directionX >= this.matrixSize || this.row + this.directionX < 0
                   || this.col + this.directionY >= this.matrixSize || this.col + this.directionY < 0
                   || this.matrix[this.row + this.directionX, this.col + this.directionY] != 0;
        }

        private bool FindValidDirection()
        {
            return this.row + this.directionX >= this.matrixSize || this.row + this.directionX < 0
                   || this.col + this.directionY >= this.matrixSize || this.col + this.directionY < 0
                   || this.matrix[this.row + this.directionX, this.col + this.directionY] != 0;
        }
    }
}