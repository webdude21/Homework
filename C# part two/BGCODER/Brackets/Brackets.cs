using System;

class Brackets
{
    static string input;
    static int solutions;
    static int halfLenght;

    static void Main()
    {
        ReadInput();
        SolveTask();
    }

    static void SolveTask() 
    {
        if ((input.Length % 2) != 0)
        {
            Console.WriteLine(0);
        }
        else
        {
            Permutate(0, 0, 0);
            Console.WriteLine(solutions);
        }
    }

    static void Permutate(int index, int openBrackets, int closedBrackets)
    {
        if (index == input.Length)
        {
            solutions++;
            return;
        }
        if (closedBrackets <= openBrackets && (closedBrackets <= halfLenght) && (openBrackets <= halfLenght))
        {
            if (input[index] == '?')
            {
                if (index < input.Length - 1)
                {
                    Permutate(index + 1, openBrackets + 1, closedBrackets);
                }
                if ((index > 0) && (closedBrackets < openBrackets))
                {
                    Permutate(index + 1, openBrackets, closedBrackets + 1);
                }
            }
            else
            {
                if (input[index] == ')' && (closedBrackets < openBrackets))
                {
                    Permutate(index + 1, openBrackets, closedBrackets + 1);
                }
                if (input[index] == '(')
                {
                    Permutate(index + 1, openBrackets + 1, closedBrackets);
                }
            }
        }
    }

    static void ReadInput()
    {
        input = Console.ReadLine();
        halfLenght = input.Length / 2;
    }
}