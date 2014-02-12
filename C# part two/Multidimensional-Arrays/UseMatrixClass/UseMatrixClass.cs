// * Write a class Matrix, to holds a matrix of integers. Overload the operators for adding, 
// subtracting and multiplying of matrices, indexer for accessing the matrix content and ToString().

using System;

class UseMatrixClass
{
    static void Main()
    {   
        Matrix matrix1 = new Matrix(2, 2);
        Matrix matrix2 = new Matrix(2, 2);
        Matrix result = new Matrix(2, 2);

        matrix1[0, 0] = 1;
        matrix1[0, 1] = 5;
        matrix1[1, 0] = 10;
        matrix1[1, 1] = 13;

        matrix2[0, 0] = 3;
        matrix2[0, 1] = 8;
        matrix2[1, 0] = 2;
        matrix2[1, 1] = 6;

        result = matrix1 * matrix2;

        Console.Write("{0} * \r\n", matrix1);
        Console.Write(matrix2);

        Console.Write(" = \r\n{0}", result);
    }
}
