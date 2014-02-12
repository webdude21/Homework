// Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
// Use the "selection sort" algorithm: Find the smallest element, move it at the first position, 
// find the smallest from the rest, move it at the second position, etc.


using System;
using System.Collections.Generic;

class SelectionSort
{
    static void Main()
	{
		// Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. 
		// Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the smallest from the rest,
		// move it at the second position, etc.

		// This is an example array of integers
		int[] intArray = { -9 ,9, -1, 6, 2, -7, 4, -1, 6, 5, 8, -8 };
        int currentMinIndex = 0;
		
		// Since we're going to sort the elements in increasing order assign the currentSmallest variable the maximum 
		// possible value for an integer.
		
		// I use an empty array with the same length to store the sorted values in it.
		
		int[] intArraySorted = new int[intArray.Length];
		
		// Here we have nested for loops to run trough the entire array and sort the numbers
		for (int currIndex = 0; currIndex < intArray.Length; currIndex++)
		{
            int currentSmallest = int.MaxValue;
			for (int sortIndex = 0; sortIndex < intArray.Length; sortIndex++)
			{
				if (intArray[sortIndex] < currentSmallest)
				{
					currentSmallest = intArray[sortIndex];
                    currentMinIndex = sortIndex;
				}
			}

            intArray[currentMinIndex] = int.MaxValue; // By setting the value to MaxValue we discard it from further sorting
            intArraySorted[currIndex] = currentSmallest;
		}
		
		Console.Write("The sorted array looks like this: ");
		for (int currIndex = 0; currIndex < intArray.Length; currIndex++)
		{
			Console.Write("{0}, ", intArraySorted[currIndex]);
		}
	}
}