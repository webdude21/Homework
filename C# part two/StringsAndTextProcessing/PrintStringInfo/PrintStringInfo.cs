// Write a program that reads a string from the console and prints all different letters in the string 
// along with information how many times each letter is found. 
namespace PrintStringInfo
{
    using System;
    using System.Collections.Generic;

    internal class PrintStringInfo
    {
        private static void Main()
        {
            var input =
                "Write a program that reads a string from the console and prints all different letters in the string";
            input = input.ToLower();
            var charArray = GetUniqueChars(input.ToCharArray());

            foreach (var chr in charArray)
            {
                if ('a' <= chr && chr <= 'z')
                {
                    Console.WriteLine("The letter {0} is used {1} time(s)", chr, GetTimesFound(input, chr));
                }
            }
        }

        private static int GetTimesFound(string input, char chr)
        {
            // This met
            var timesFound = -1;
            var startindex = -1;
            do
            {
                startindex = input.IndexOf(chr, startindex + 1);
                timesFound++;
            }
            while (startindex > -1);
            return timesFound;
        }

        private static char[] GetUniqueChars(char[] chars)
        {
            // This methods gets only the unique chars from a char array
            // returns an array of unique chars
            Array.Sort(chars);
            var uniqueChars = new List<char>();
            char? currentChar = null;

            for (var chr = 0; chr < chars.Length; chr++)
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
}