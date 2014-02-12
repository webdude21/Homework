using System;

//Write a program that finds the sequence of maximal sum in given array. Example:
//    {2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
//    Can you do it with only one loop (with single scan through the elements of the array)?


class MaxSequenceWithOneLoop
{
    static void Main()
    {
        Console.Write("Please input a valid integer for the number of integers to expect: ");
        int arrLenght;
        bool validInput = int.TryParse(Console.ReadLine(), out arrLenght);
        // Restart the application if the input is invalid

        if (!validInput)
        {
            Main();
        }

        int[] intArray = new int[arrLenght];

        //enter array elements
        for (int i = 0; i < intArray.Length; i++)
        {
            Console.Write("Please enter an integer for element {0} of the array: ", i + 1);
            bool success = int.TryParse(Console.ReadLine(), out intArray[i]);
            if (!success)
            {
                i--;
            }
        }

        int max = intArray[0], maxEnd = intArray[0];
        int longSequence = 1, currentSequence = 1;
        int start = 0, startTemp = 0;

        //Kadane's algorithm
        for (int i = 1; i < intArray.Length; ++i)
        {
            if (intArray[i] + maxEnd > intArray[i])
            {
                maxEnd = intArray[i] + maxEnd;
                currentSequence++;
            }

            else
            {
                maxEnd = intArray[i];
                startTemp = i;
                currentSequence = 1;
            }
            if (maxEnd > max)
            {
                max = maxEnd;
                longSequence = currentSequence;
                start = startTemp;
            }
        }
        //Print the resulting array

        Console.Write("The result is: ");

        for (int i = start; i < start + longSequence; ++i)
        {
            Console.Write("{0} ", intArray[i]);
        }
    }
}