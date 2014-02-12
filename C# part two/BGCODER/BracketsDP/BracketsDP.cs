using System;
using System.Numerics;

class BracketsDP
{
    static void Main()
    {

        string input = Console.ReadLine();
        int count = input.Length;
        if (input[0] == ')' || input[count - 1] == '(' || count % 2 != 0)
        {
            Console.WriteLine(0);
        }
        else 
        {
            SolveTask(input, count);
        }
    }

    static void SolveTask(string input, int count)
    {
        BigInteger[,] solutions = new BigInteger[count + 1, count + 2];
        solutions[0, 0] = 1;
        for (int row = 1; row < count + 1; row++)
        {
            if (input[row - 1] == '(')
            {
                solutions[row, 0] = 0;
            }
            else
            {
                solutions[row, 0] = solutions[row - 1, 1];
            }

            for (int col = 1; col < count + 1; col++)
            {
                if (input[row - 1] == '(')
                {
                    solutions[row, col] = solutions[row - 1, col - 1];
                }
                else if (input[row - 1] == ')')
                {
                    solutions[row, col] = solutions[row - 1, col + 1];
                }
                else
                {
                    solutions[row, col] = solutions[row - 1, col - 1] + solutions[row - 1, col + 1];
                }
            }
        }
        Console.WriteLine(solutions[count, 0]);
    }
}