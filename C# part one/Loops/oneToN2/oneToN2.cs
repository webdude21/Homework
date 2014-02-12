using System;

class OneToN2
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
            // If the input isn't valid we call the Main method again and start from the beginning.
        }

        for (int i = 1; i <= userInput; i++)
        {
            if (i % 21 != 0)
            {
                Console.WriteLine(i);
            }
        }
        // The loop only prints numbers that are not divisible by 3 and 7 at the same tame.
        // In order for a number to be advisable by 3 and 7 at the same time, then it must be
        // divisible by their product which is 21.
    }
}
