// Write a method that return the maximal element in a portion of array of integers starting at given index. 
// Using it write another method that sorts an array in ascending / descending order.

using System;

class SortingRevisited
{
    static void Main()
    {
        int[] testArray = { 1, 2, 9, 9, 9, 5, 2, 0, 0, 1, 2, 5, 4, 4, 5, 1, 4, 3, 2, 4, 0, 1, 7, 5, 4, 4, 5, 1, 4, 3, 2, 4 };
        Console.WriteLine("This is the initial array:");
        PrintArray(testArray);
        Console.WriteLine("This is the sorted array (Descending):");
        PrintArray(SortArrayDescending(testArray));
        Console.WriteLine("This is the sorted array (Ascending):");
        PrintArray(SortArrayAscending(testArray));
    }
    static int GetMaximalElement(int[] array, int startIndex)
    { 
        // The only thing this does is to return the position of the 
        // largest element in range selected
        int maxNumberIndex = startIndex;
        for (int i = startIndex; i < array.Length; i++)
        {
            if (array[i] > array[maxNumberIndex])
            {
                maxNumberIndex = i;
            }
        }
        return maxNumberIndex;
    }

    static int[] SortArrayDescending(int[] array)
    { // Selection sort algorythm
        for (int i = 0; i < array.Length; i++)
        {
            int maxIndex = GetMaximalElement(array, i);
            int temp = array[i];
            array[i] = array[maxIndex];
            array[maxIndex] = temp;
        }

        return array;
    }
    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ", array[i]);
        }
        Console.WriteLine();
    }

    static int[] SortArrayAscending(int[] array)
    {
        // Here I reverse the array after it has been sorted in a descending way.
        Array.Reverse(SortArrayDescending(array));

        return array;
    }
}
