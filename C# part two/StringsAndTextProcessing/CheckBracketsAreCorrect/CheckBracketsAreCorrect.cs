// Write a program to check if in a given expression the brackets are put correctly.
// Example of correct expression: ((a+b)/5-d).
// Example of incorrect expression: )(a+b)).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class CheckBracketsAreCorrect
{
    static void Main()
    {  
        Console.Write("Please input an expression: ");
        string expression = Console.ReadLine();
        PrintResult(IsValidExpression(expression));
    }

    static void PrintResult(bool isValid)
    {   // This just prints the result
        if (isValid)
        {
            Console.WriteLine("The expression is valid");
        }
        else
        {
            Console.WriteLine("The expression isn't valid");
        }
    }

    static bool IsValidExpression(string expression)
    {
        // This is the method used for the bracket validation
        // I have a feeling is more complicated then needed, but that's it.
        int openBracket = 0;
        int closedBracket = 0;
        bool isValid = true;

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                openBracket++;
            }
            else if (expression[i] == ')')
            {
                closedBracket++;
            }
            // If at any given point we have more closed brackets then opened
            // Then something is wrong
            if (closedBracket > openBracket)
            {
                isValid = false;
            }
        }

        if (isValid == false || openBracket != closedBracket)
        {
            isValid = false;
        }
        return isValid;
    }
}
