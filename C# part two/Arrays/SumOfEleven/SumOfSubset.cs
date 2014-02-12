// Write a program that finds in given array of integers a sequence of given sum S (if present). 
// Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11 >>> {4, 2, 5}

using System;
using System.Collections.Generic;

class SumOfSubset
{
    static void Main()
	{
		// This prompts the user to enter the length of the array that's going to be used.
		Console.Write("Please input the length of the array: ");
		int arrayL; // This is the length of the array
		bool result = int.TryParse(Console.ReadLine(), out arrayL);
		// This prompts the user to input sum to look for.
        Console.Write("Please input input sum to look for: ");
		int sum;
		bool resultSum  = int.TryParse(Console.ReadLine(), out sum);

		
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
			Console.Write("Please input a valid integer for element {0} of the array: ", currentIndex + 1);
			bool correctInput = int.TryParse(Console.ReadLine(), out array[currentIndex]);
			if (!correctInput)
			{
				currentIndex--;
			}
		}
		
		int currentSum = 0;
		int elementsCount = 0;
		int startIndex = 0;
        int endIndex = 0;
		
		for (int currentIndex = 0; currentIndex < arrayL; currentIndex++)
		{	
			currentSum = currentSum + array[currentIndex];
			
			if (currentSum == sum)
			{
                startIndex = currentIndex - elementsCount;
                endIndex = currentIndex;
				break;
				// If the currentSum is equal to sum then we break the cycle
				// and print the result
			}
		
			if (currentSum < sum)
			{
				// if the sum is less then sum we're looking for we continue to increase it
				elementsCount++;
			}
			else 
			{	
				// if the the current sum is more the the sum we look for we retry at the position
				// after the one that we started with
				currentIndex = currentIndex - elementsCount;
				elementsCount = 0;
                currentSum = 0;
			}
		} 
		
		// The following loop is used to visualize the result
		Console.Write("The result is: <");

        for (int i = startIndex; i <= endIndex; i++)
		{	
			if (i == endIndex)
			{
				Console.WriteLine("{0}>", array[i]);
			}
			else 
			{
				Console.Write("{0}, ", array[i]);
			}
		}
	}
}