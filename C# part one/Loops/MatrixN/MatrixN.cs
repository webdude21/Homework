using System;

class MatrixN
{
    static void Main()
    {
        // Write a program that reads from the console a positive integer number N 
        // (N < 20) and outputs a matrix like the following:
        int userInput;
        bool validInput;

        Console.Write("Please input a number for 'N': ");
        validInput = int.TryParse(Console.ReadLine(), out userInput);

        if (validInput == false || userInput > 20 || userInput < 1)
        {
            Console.WriteLine("The input wasn't valid");
            Main();
            // If the input isn't valid we call the Main method again and start from the beginning.
        }

        else
        {
            for (int p = 1; p < userInput+1; p++) 
            {
                Console.WriteLine();
                for (int i = 0; i < userInput; i++)
                {
                    Console.Write(" {0} ", i+p);
                }
            }
            Console.WriteLine("\r\n");
        }

    }
}
