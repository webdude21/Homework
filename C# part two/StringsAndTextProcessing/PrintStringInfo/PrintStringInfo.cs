// Write a program that reads a string from the console and prints all different letters in the string 
// along with information how many times each letter is found. 

using System;
using System.Collections.Generic;

class PrintStringInfo
{
    static void Main()
    {
        string input = "Write a program that reads a string from the console and prints all different letters in the string";
        input = input.ToLower();
        char[] charArray = GetUniqueChars(input.ToCharArray());

        foreach (char chr in charArray)
        {
            if ('a' <= chr && chr <= 'z')
            {
                Console.WriteLine("The letter {0} is used {1} time(s)", chr, GetTimesFound(input, chr));
            }
        }
    }

    static int GetTimesFound(string input, char chr)
    { // This met
        int timesFound = -1;
        int startindex = -1;
        do
        {
            startindex = input.IndexOf(chr, startindex + 1);
            timesFound++;

        } while (startindex > -1);
        return timesFound;
    }

    static char[] GetUniqueChars(char[] chars)
    {   // This methods gets only the unique chars from a char array
        // returns an array of unique chars
        Array.Sort(chars);
        List<char> uniqueChars = new List<char>();
        char? currentChar = null;

        for (int chr = 0; chr < chars.Length; chr++)
        {
            if (currentChar != chars[chr])
            {
                currentChar = chars[chr];
                uniqueChars.Add(chars[chr]);
            }
        }
        return uniqueChars.ToArray();
    }
}