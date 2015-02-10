// Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
namespace CheckForPalindromes
{
    using System;

    internal class CheckForPalindromes
    {
        private static void Main()
        {
            // The logic is simple, if a word is the same spelled backwords then it's a palindrome
            var input = "Some of the words are ABBA, lamal, exe, anna, ana";
            char[] delimiters = { '.', '-', ',', ';', '?', '!', ' ' };
            var wordList = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("These are the palindromes in the text:");

            foreach (var word in wordList)
            {
                if (word == ReverseString(word))
                {
                    Console.WriteLine(word);
                }
            }
        }

        private static string ReverseString(string str)
        {
            // This is the method from the task 2 of the homework
            var stringAsChars = str.ToCharArray();
            Array.Reverse(stringAsChars);
            return new string(stringAsChars);
        }
    }
}