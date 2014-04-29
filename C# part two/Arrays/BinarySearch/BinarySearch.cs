// Write a program that finds the index of given element in a sorted array of 
// integers by using the binary search algorithm (find it in Wikipedia).

using System;
using System.Collections.Generic;

class BinarySearch
{
    static void Main()
    {
        // This prompts the user to enter the length of the array that's going to be used.
        Console.Write("Please input the length of the array: ");
        int arrayL; // This is the length of the array
        bool result = int.TryParse(Console.ReadLine(), out arrayL);
        // This prompts the user to input the number to look for.
        Console.Write("Please input a number to look for: ");
        int keyNumber;
        bool resultSum = int.TryParse(Console.ReadLine(), out keyNumber);

        // If the input is not valid we prompt the user for new input
        if (!(result || resultSum))
        {
            Main();
        }
        // Initialize the array 
        int[] array = new int[arrayL];

        // Fill the array with user input
        for (int currentIndex = 0; currentIndex < arrayL; currentIndex++)
        {
            // Here we check if the input is a valid integer, if not we retry by decreasing currentIndex with 1
            Console.Write("Please input a valid integer for element {0} of the array: ", currentIndex);
            bool correctInput = int.TryParse(Console.ReadLine(), out array[currentIndex]);
            if (!correctInput)
            {
                currentIndex--;
            }
        }
        // Sort the array
        Array.Sort(array);
        // Find the index
        int indexWhereFound = Search(keyNumber, array);

        // print the result
        if (indexWhereFound > -1)
        {
            Console.WriteLine("The integer you're looking for is at position {0} in the sorted array", indexWhereFound);
        }
        else
        {
            Console.WriteLine("The integer you're looking for was not found", indexWhereFound);
        }
    }

    private static int Search(int keyNumber, int[] array)
    {
        int indexWhereFound = -1;
        int right = array.Length;
        int left = 0;
        int middle = right / 2;

        // Implement the binary search
        for (int currentIndex = left; currentIndex < right; currentIndex++)
        {
            middle = right / 2;
            if (array[currentIndex] == keyNumber)
            {
                indexWhereFound = currentIndex;
                break;
            }
            if (keyNumber > middle)
            {
                left = middle; // Those constrain the search bounds 
            }
            else if (keyNumber < right)
            {
                right = middle; // Those constrain the search bounds 
            }
        }
        return indexWhereFound;
    }
}