// Write a program that creates an array containing all letters from the alphabet (A-Z).
// Read a word from the console and print the index of each of its letters in the array.

using System;

class IndexOfLetters
{
    static void Main()
	{
		// Initialize an array to hold the chars (in this case their representation as integers in the ASCII table.
		// A is number 65 in the ASCII table and Z is 90 in the ASCII table.

        // Note that the program works only with capittal Leters (as it states in the exircese itself)

        int[] AToZArray = new int[26];
		int arrIndex = 0;
			
		for (int i = 'A'; i <= 'Z'; i++)
		{
			AToZArray[arrIndex] = i;
			arrIndex++;
		}

        Console.Write("Please write a word: ");
		string word = Console.ReadLine();
		char[] wordAsChars = word.ToCharArray();
		
		for (int i = 0; i < word.Length; i++)
		{
			for (int j = 0; j < AToZArray.Length; j++)
			{
                if (wordAsChars[i] == AToZArray[j])
				{
					Console.WriteLine("The index of {0} is {1}!", wordAsChars[i], j);
				}
			}
		}
	}
}