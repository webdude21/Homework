using System;

class UseMatrixClass
{
    static void Main()
    {
        Matrix<int> matrix1 = new Matrix<int>(2, 2);
        Matrix<int> matrix2 = new Matrix<int>(2, 2);
        Matrix<int> result = new Matrix<int>(2, 2);
        Matrix<int> emptyMatrix = new Matrix<int>(4, 4);

        matrix1[0, 0] = 1;
        matrix1[0, 1] = 5;
        matrix1[1, 0] = 10;
        matrix1[1, 1] = 13;

        matrix2[0, 0] = 3;
        matrix2[0, 1] = 8;
        matrix2[1, 0] = 2;
        matrix2[1, 1] = 6;

        result = matrix1 * matrix2;

        Console.WriteLine();
        Console.Write("{0} * \r\n", matrix1);
        Console.Write(" = \r\n{0}", result);

        if (emptyMatrix)
        {
            Console.WriteLine("The matrix is not empty");
        }
        else
        {
            Console.WriteLine("The matrix is empty");
        }

    }
}
