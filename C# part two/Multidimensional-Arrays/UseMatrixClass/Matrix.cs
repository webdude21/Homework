using System;
using System.Text;

class Matrix
{
    private int[,] matrix;

    public Matrix(int rows, int cols)
    {
        this.matrix = new int[rows, cols];
    }
    public int Rows
    {
        get
        {
            return this.matrix.GetLength(0);
        }
    }

    public int Columns
    {
        get
        {
            return this.matrix.GetLength(1);
        }
    }

    public int this[int row, int col]
    {
        get
        {
            return this.matrix[row, col];
        }

        set
        {
            this.matrix[row, col] = value;
        }
    }

    public static Matrix operator +(Matrix first, Matrix second)
    {
        Matrix result = new Matrix(first.Rows, first.Rows);

        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = first[row, col] + second[row, col];
            }
        }
        return result;
    }

    public static Matrix operator *(Matrix first, Matrix second)
    {
        Matrix result = new Matrix(first.Rows, first.Rows);

        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = first[row, col] * second[row, col];
            }
        }
        return result;
    }

    public static Matrix operator -(Matrix first, Matrix second)
    {
        Matrix result = new Matrix(first.Rows, first.Rows);

        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = first[row, col] - second[row, col];
            }
        }
        return result;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        for (int row = 0; row < this.Rows; row++)
        {
            for (int col = 0; col < this.Columns; col++)
            {
                result.Append(matrix[row,col] + " ");
            }
            result.Append(Environment.NewLine);
        }
        return result.ToString();
    }
}