// Write a method that counts how many times given number appears in given array.
// Write a test program to check if the method is working correctly.

using System;

class ReoccurenceOfNumber
{
    static void Main()
    {
        int[] testArray = { 1, 2, 6, 8, 10, 15, 42, 2, 4, 2, 2, 8, 9 };
        int numberToLookFor = 2;
        Console.WriteLine("The number '{0}' repeats {1} times in the array.", numberToLookFor,
        CountReoccurenceInArray(testArray, numberToLookFor));
    }

    static int CountReoccurenceInArray(int[] array, int number)
    {
        int reoccurence = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == number)
            {
                reoccurence++;
            }
        }
        return reoccurence;
    }
}

