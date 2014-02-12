using System;

class NSpiral
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
            int[,] matrix = new int[userInput, userInput];
            int row = 0;
            int col = 0;
            string direction = "right";
            int maxRotations = userInput * userInput;

            for (int i = 1; i <= maxRotations; i++)
            {
                if (direction == "right" && (col > userInput - 1 || matrix[row, col] != 0))
                {
                    direction = "down";
                    col--;
                    row++;
                }
                if (direction == "down" && (row > userInput - 1 || matrix[row, col] != 0))
                {
                    direction = "left";
                    row--;
                    col--;
                }
                if (direction == "left" && (col < 0 || matrix[row, col] != 0))
                {
                    direction = "up";
                    col++;
                    row--;
                }

                if (direction == "up" && row < 0 || matrix[row, col] != 0)
                {
                    direction = "right";
                    row++;
                    col++;
                }

                matrix[row, col] = i;

                if (direction == "right")
                {
                    col++;
                }
                if (direction == "down")
                {
                    row++;
                }
                if (direction == "left")
                {
                    col--;
                }
                if (direction == "up")
                {
                    row--;
                }
            }

            // Display Matrix

            for (int r = 0; r < userInput; r++)
            {
                for (int c = 0; c < userInput; c++)
                {
                    Console.Write("{0,4}", matrix[r, c]);
                }
                Console.WriteLine();
            }

        }
    }
}