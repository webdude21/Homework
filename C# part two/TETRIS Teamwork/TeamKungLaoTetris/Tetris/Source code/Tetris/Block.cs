using System;

namespace Tetris
{
    public class Block
    {
        public int blockPositionX;
        public int blockPositionY;
        public int blockRows;
        public int blockCols;
        public int filledCells;
        public int[,] block;

        public Block(int positionX, int positionY, int[,] blockData)
        {
            blockPositionX = positionX;
            blockPositionY = positionY;
            filledCells = 0;
            blockRows = blockData.GetLength(1);
            blockCols = blockData.GetLength(0);

            block = new int[blockCols, blockRows];

            for (int indexRows = 0; indexRows < blockRows; indexRows++)
            {
                for (int indexCols = 0; indexCols < blockCols; indexCols++)
                {
                    block[indexCols, indexRows] = blockData[indexCols, indexRows];
                    if (blockData[indexCols, indexRows] != 0 ) filledCells++;
                }
            }
        }
        public Block Clone()
        {
            Block result = new Block(blockPositionX, blockPositionY, new int[blockCols, blockRows]);

            for (int indexRows = 0; indexRows < blockRows; indexRows++)
            {
                for (int indexCols = 0; indexCols < blockCols; indexCols++)
                {
                    result[indexCols, indexRows] = this[indexCols, indexRows];
                }
            }
            return result;
        }
        public Block Rotate()
        {
            int[,] newBlock = new int[this.block.GetLength(1), this.block.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = this.block.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < this.block.GetLength(0); oldRow++)
                {
                    newBlock[newRow, newColumn] = this.block[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return new Block(this.blockPositionX, this.blockPositionY, newBlock);
        }
        public void SetColor(int color)
        {
            for (int indexRows = 0; indexRows < blockRows; indexRows++)
            {
                for (int indexCols = 0; indexCols < blockCols; indexCols++)
                {
                    if (this[indexCols, indexRows] != 0) this[indexCols, indexRows]=color;
                }
            }
        }
        public static Block operator +(Block a, Block b)
        {
            int rows, cols, x, y;

            //// get Uperr left cordinate 
            if (a.blockPositionX < b.blockPositionX) x = a.blockPositionX;
            else x = b.blockPositionX;
            if (a.blockPositionY < b.blockPositionY) y = a.blockPositionY;
            else y = b.blockPositionY;

            //// size of new Block
            if (a.blockRows + a.blockPositionY > b.blockRows + b.blockPositionY)
                rows = a.blockRows + a.blockPositionY - y;
            else rows = b.blockRows + b.blockPositionY - y;
            if (a.blockCols + a.blockPositionX > b.blockCols + b.blockPositionX)
                cols = a.blockCols + a.blockPositionX - x;
            else cols = b.blockCols + b.blockPositionX - x;

            Block result = new Block(x, y, new int[cols, rows]);

            for (int r = b.blockPositionY; r < b.blockRows + b.blockPositionY; r++)
            {
                for (int c = b.blockPositionX; c < b.blockCols + b.blockPositionX; c++)
                {
                    if (b[c - b.blockPositionX, r - b.blockPositionY] != 0)
                        result[c - result.blockPositionX, r - result.blockPositionY] = b[c - b.blockPositionX, r - b.blockPositionY];
                }
            }

            for (int r = a.blockPositionY; r < a.blockRows + a.blockPositionY; r++)
            {
                for (int c = a.blockPositionX; c < a.blockCols + a.blockPositionX; c++)
                {
                    if (a[c - a.blockPositionX, r - a.blockPositionY] != 0)
                        result[c - result.blockPositionX, r - result.blockPositionY] = a[c - a.blockPositionX, r - a.blockPositionY];
                }
            }
            return result;
        }
        public static bool OverlapBlocks(params Block[] input)
        {
            int filledCellsOfInput = input[0].filledCells;
            Block result=input[0];
            for (int i = 1; i < input.Length; i++)
			{
			 result+=input[i];
             filledCellsOfInput += input[i].filledCells;  
			}
            if (filledCellsOfInput == result.filledCells)
                return false;
            else return true;
        }
        public int this[int x, int y]
        {
            get
            {
                return block[x, y];
            }
            set
            {
                if (value != 0 && block[x, y] == 0) filledCells++;
                if (block[x, y] != 0 && value == 0) filledCells--;
                block[x, y] = value;
            }
        }
        public int FilledCells()
        {
            return filledCells;
        }
        public int Rows()
        {
            return blockRows;
        }
        public int Cols()
        {
            return blockCols;
        }
        public void Clear()
        {
            for (int x = 0; x < blockCols; x++)
            {
                for (int y = 0; y < blockRows; y++)
                {
                    if (this[x, y] != 0)
                    {
                        Console.SetCursorPosition((blockPositionX + x) * 2, blockPositionY + y);
                        Console.BackgroundColor = (ConsoleColor)0;
                        Console.Write("  ");
                    }
                }
            }
        }
        public void Print(params int[] posiotion)
        {
            int xCurrent = blockPositionX;
            int yCurrent = blockPositionY;
            if (posiotion.Length==2)
            {
                blockPositionX = posiotion[0];
                blockPositionY = posiotion[1];
            }
            int val;
            Console.ForegroundColor = (ConsoleColor)0;
            for (int x = 0; x < blockCols; x++)
            {
                for (int y = 0; y < blockRows; y++)
                {
                    val = this[x, y];
                    if (val != 0)
                    {
                        Console.SetCursorPosition((blockPositionX + x) * 2, blockPositionY + y);
                        Console.BackgroundColor = (ConsoleColor)val;
                        Console.Write("[]");
                    }
                }
            }
             blockPositionX=xCurrent;
             blockPositionY=yCurrent;
            Console.SetCursorPosition(34, 0);
            Console.ForegroundColor = (ConsoleColor)0;
            Console.BackgroundColor = (ConsoleColor)0;
        }
    }
}