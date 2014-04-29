// Write a program that finds the maximal sequence of equal elements in an array.

using System;

class MaxSequenceInArray
{
    static void Main()
    {
        Console.Write("Please input a valid integer for the number of integers to expect: ");
        int nubmerOfMembers;
        var maxLen = 1;
        var len = 1;
        var longestOne = 0;
        var validInput = int.TryParse(Console.ReadLine(), out nubmerOfMembers);
        // Restart the application if the input is invalid
        if (!validInput)
        {
            Main();
        }

        var arr = new int[nubmerOfMembers]; // Initialize the array using the input from the user

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
            if (arr[i] == arr[i + 1])
            {
                len++;
            }
            else
            {
                if (len > maxLen)
                {
                    maxLen = len;
                    longestOne = arr[i];
                }
                len = 1;
            }
        }

        if (len > maxLen)
        {
            maxLen = len;
            longestOne = arr[arr.Length - 1];
        }

        Console.WriteLine("The longest sequence is formed by {0} elements of \"{1}\" .", maxLen, longestOne);
    }
}