using System;

class OneToN
{
    static void Main()
    {
        int userInput;
        bool validInput;

        Console.Write("Please input a number for 'N': ");
        validInput = int.TryParse(Console.ReadLine(), out userInput);

        if (validInput == false)
        {
            Console.WriteLine("The input wasn't valid");
            Main();
            // If the input isn't valid we call the Main method again and start from the beggining.
        }

        for (int i = 1; i <= userInput; i++)
        {
            Console.WriteLine(i);
        }
        // The loop prints every nubmer from 1 to N.
    }
}
