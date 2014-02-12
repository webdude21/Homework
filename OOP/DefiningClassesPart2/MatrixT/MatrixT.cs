// Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 
// Implement an indexer this[row, col] to access the inner matrix cells.
// Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication.
// Throw an exception when the operation cannot be performed. Implement the true operator (check for non-zero elements).

using System;
using System.Text;

class Matrix<T>
{
    private T [,] matrix; 

    public Matrix(int rows, int cols)
    {
        this.matrix = new T[rows, cols];
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

    public T this[int row, int col]
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

    public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
    {
        CheckMatricesSize(first, second);

        Matrix<T> result = new Matrix<T>(first.Rows, first.Rows);
        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = (dynamic)first[row, col] + second[row, col];
            }
        }
        return result;
    }

    private static void CheckMatricesSize(Matrix<T> first, Matrix<T> second)
    {
        if (first.Rows != second.Rows)
        {
            throw new InvalidOperationException("The matrices must be of the same size in order to apply this operation.");
        }
    }

    public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
    {
        CheckMatricesSize(first, second);

        Matrix<T> result = new Matrix<T>(first.Rows, first.Rows);
        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = (dynamic)first[row, col] * second[row, col];
            }
        }
        return result;
    }

    public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
    {
        CheckMatricesSize(first, second);
        Matrix<T> result = new Matrix<T>(first.Rows, first.Rows);

        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = (dynamic)first[row, col] - second[row, col];
            }
        }
        return result;
    }

    public static bool operator true(Matrix<T> matrix)
    {
        foreach (T item in matrix.matrix)
        {
            if (item.Equals(default(T)))
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator false(Matrix<T> matrix)
    {
        return true;
    }
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        for (int row = 0; row < this.Rows; row++)
        {
            for (int col = 0; col < this.Columns; col++)
            {
                result.Append(matrix[row, col] + " ");
            }
            result.Append(Environment.NewLine);
        }
        return result.ToString();
    }
}