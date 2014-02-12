using System;
using System.Linq;

class ExerciseSix
{
    static void Main()
    {
        // Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN

        int userInputN = 0;
        int userInputX = 0;
        bool validInputN = false;
        bool validInputX = false;
        double sum = 1;
        double tempFact;

        Console.WriteLine("Please input a number for 'N' and 'X' on separate lines: ");
        Console.Write("N = ");
        validInputN = int.TryParse(Console.ReadLine(), out userInputN);
        Console.Write("X = ");
        validInputX = int.TryParse(Console.ReadLine(), out userInputX);

        // Check the validity of the input, and if it's not valid restart the Main() method.
        // It's not required in the exirces, but I do a check if 'n' is is not negative because factorial calculation of a
        // negative number will not work (shouldn't work).

        if (validInputN == false || validInputX == false || userInputN <= 0)
        {
            Console.WriteLine("The input wasn't valid ...");
            Main();
        }
        else
        {
            for (int i = 1; i <= userInputN; i++)
            {
                tempFact = 1; // this is used for the current factorial 
                // Only execute this loop to calculate the factorial of the current number if it's larger then 1.
                // Otherwise use 1 
                if (i > 1) 
                {
                    for (int p = i; 1 < p; p--) // this is N
                    {
                        if (p > 1)
                        {
                            tempFact = tempFact * p;
                        }
                    }
                }
                sum = sum + tempFact / (Math.Pow(userInputX, i));
            }
            Console.WriteLine(sum); // Print the final sum.
        }
    }
}

