// Write a program to check if in a given expression the brackets are put correctly.
// Example of correct expression: ((a+b)/5-d).
// Example of incorrect expression: )(a+b)).
namespace CheckBracketsAreCorrect
{
    using System;

    internal class CheckBracketsAreCorrect
    {
        private static void Main()
        {
            Console.Write("Please input an expression: ");
            var expression = Console.ReadLine();
            PrintResult(IsValidExpression(expression));
        }

        private static void PrintResult(bool isValid)
        {
            // This just prints the result
            if (isValid)
            {
                Console.WriteLine("The expression is valid");
            }
            else
            {
                Console.WriteLine("The expression isn't valid");
            }
        }

        private static bool IsValidExpression(string expression)
        {
            // This is the method used for the bracket validation
            // I have a feeling is more complicated then needed, but that's it.
            var openBracket = 0;
            var closedBracket = 0;
            var isValid = true;

            for (var i = 0; i < expression.Length; i++)
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
}