// Write a program that compares two char arrays lexicographically (letter by letter).

using System;

class compareTwoCharArrays
{
    static void Main()
    {
        Console.Write("Please enter the chars of the first array on one line without spaces: ");
        string firstArray = Console.ReadLine();
        Console.Write("Please enter the chars of the second array on one line without spaces: ");
        string secondArray = Console.ReadLine();
        // We get two strings and dissolve them two char arrays.
        int smallerArray = 0;
        
        // I check and use the lenght of the smaller string as a ending point for the array.
        if (firstArray.Length < secondArray.Length)
        {
            smallerArray = firstArray.Length;
        }
        else
        {
            smallerArray = secondArray.Length;
        }

        // I convert the arrays 

        char[] charArr1 = firstArray.ToCharArray();
        char[] charArr2 = secondArray.ToCharArray();

        // Compare the arrays char by char
        for (int i = 0; i < smallerArray; i++)
        {
            if (charArr1[i] == charArr2[i])
            {
                Console.WriteLine("Char {0} in both arrays is the same!", i + 1);
            }
            else
            {
                Console.WriteLine("Char {0} in both arrays is different!", i + 1);
            }
        }
    }
}