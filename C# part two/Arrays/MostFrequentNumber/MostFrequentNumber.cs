// Write a program that finds the most frequent number in an array. Example:
//	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)

using System;
using System.Collections.Generic;

class MostFrequentNumber
{
    static void Main()
	{
		// This prompts the user to enter the length of the array that's going to be used.
		Console.Write("Please input the length of the array: ");
		int arrayL; // This is the length of the array
		bool result = int.TryParse(Console.ReadLine(), out arrayL);
		
		// If the array length is not a valid integer then retry
		if (!result)
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
		
		// After we have our input we sort the array so it's more manageable
		
		Array.Sort(array);
		int currentMostFrequent = array[0];
		int bestFrequent = array[0];
		int frequancyCount = 1;
		int frequancyMax = 1;
		
		for (int currentIndex = 1; currentIndex < arrayL; currentIndex++)
		{
			if (currentMostFrequent == array[currentIndex])
			{
				frequancyCount++;
			}
			else
			{
				if (frequancyCount > frequancyMax)
				{
				bestFrequent = currentMostFrequent;
				currentMostFrequent = array[currentIndex];
				frequancyMax = frequancyCount;
				frequancyCount = 1;
				}
				else
				{
				currentMostFrequent = array[currentIndex];
				frequancyCount = 1;
				}
			}
		}
		Console.WriteLine("The most frequent member is {0}, and it is repeated {1} time(s)", bestFrequent, frequancyMax);
	}
}