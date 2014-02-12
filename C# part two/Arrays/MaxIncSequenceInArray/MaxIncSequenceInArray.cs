// Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4} >> {2, 3, 4}.

using System;

class MaxSequenceInArray
{
    static void Main()
    {
        Console.Write("Please input a valid integer for the number of integers to expect: ");
        int nubmerOfMembers;
        int maxLen = 1;
        int len = 1;
        string sequence = "";
        string bestSequence = "";
        bool validInput = int.TryParse(Console.ReadLine(), out nubmerOfMembers);
        // Restart the application if the input is invalid
        if (!validInput)
        {
            Main();
        }

        int[] arr = new int[nubmerOfMembers]; // Initialize the array using the input from the user

        for (int i = 0; i < nubmerOfMembers; i++)
        {
            Console.Write("Please input a valid integer for member {0} in the array: ", i + 1);
            bool result = int.TryParse(Console.ReadLine(), out arr[i]);

            if (!result)
            {
                i--; // If the input is invalid then try to input the integer again
            }
        }

        for (int i = 0; i < nubmerOfMembers - 1; i++)
        {
            if (arr[i] + 1 == arr[i + 1])
            {
                len++;
                sequence = sequence + " " + arr[i];
            }
            else
            {
                if (len > maxLen)
                {
                    maxLen = len;
                    bestSequence = sequence  + " " + arr[i];
                }
                len = 1;
                sequence = arr[i].ToString();
            }
        }

        if (len > maxLen)
        {
            maxLen = len;
            bestSequence = bestSequence + arr[arr.Length - 1];
        }

        Console.WriteLine("The longest sequence is {0}", bestSequence);
    }
}