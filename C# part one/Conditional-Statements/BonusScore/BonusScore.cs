using System;

class BonusScore
{

    // Write a program that applies bonus scores to given scores in the range [1..9]. The program reads a digit 
    // as an input. If the digit is between 1 and 3, the program multiplies it by 10; if it is between 4 and 6,
    // multiplies it by 100; if it is between 7 and 9, multiplies it by 1000. If it is zero or if the value is 
    // not a digit, the program must report an error.

    static void Main(string[] args)
    {
        int userInput;
        bool validInput;

        Console.Write("Please input a score in the range from 1 to 9: ");
        validInput = int.TryParse(Console.ReadLine(), out userInput);

        // If the user input cannot succesfuly be Parsed, then user input will be set to 0 and can be later on
        // be managed by the switch statement.

        if (validInput == false)
        {
            userInput = 0;
        }

        // I used a switch statement. This could be easely be done by an If statement as well.
        switch (userInput)
        {
            case 1:
            case 2:
            case 3:
                Console.WriteLine("The result is {0}", userInput * 10);
                break;
            case 4:
            case 5:
            case 6:
                Console.WriteLine("The result is {0}", userInput * 100);
                break;
            case 7:
            case 8:
            case 9:
                Console.WriteLine("The result is {0}", userInput * 1000);
                break;
            default: Console.WriteLine("The input was incorect");
                break;
        }
    }
}
