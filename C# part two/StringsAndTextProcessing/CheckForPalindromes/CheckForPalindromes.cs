// Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

using System;

class CheckForPalindromes
{
    static void Main()
    {
        // The logic is simple, if a word is the same spelled backwords then it's a palindrome
        string input = "Some of the words are ABBA, lamal, exe, anna, ana";
        char[] delimiters = { '.', '-', ',', ';', '?', '!', ' ' };
        string[] wordList = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine("These are the palindromes in the text:");

        foreach (string word in wordList)
        {
            if (word == ReverseString(word))
            {
                Console.WriteLine(word);
            }
        }
    }

    static string ReverseString(string str)
    {   // This is the method from the task 2 of the homework
        char[] stringAsChars = str.ToCharArray();
        Array.Reverse(stringAsChars);
        return new string(stringAsChars);
    }
}