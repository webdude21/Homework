using System;
using System.Linq;

class SequenceNintegers
{
    static void Main()
    {
        // Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

        int userInput;
        bool validInput;

        Console.Write("Please input a number for 'N': ");
        validInput = int.TryParse(Console.ReadLine(), out userInput);

        if (validInput == false || userInput < 1)
        {
            Console.WriteLine("The input wasn't valid");
            Main();
        // If the input isn't valid we call the Main method again and start from the beginning.
        }

        // After we know how many integers we're going to have then we declare an array with that many spaces
        int[] nIntegers = new int[userInput];
        // Then I use a loop to gather all of the members of the array (the n integers)
        for (int i = 0; i < userInput; i++)
        {
            Console.Write("Please input the integer No {0}:", i+1);
            validInput = int.TryParse(Console.ReadLine(), out nIntegers[i]);

            if (validInput == false )

            {
                Console.WriteLine("The input wasn't valid");
                i--;
            }
        }

        Console.WriteLine("The smallest integer is '{0}', and the largest is '{1}'!", nIntegers.Min(), nIntegers.Max());
        // After we've gathered all of the necessary information we print the result.
    }
}
