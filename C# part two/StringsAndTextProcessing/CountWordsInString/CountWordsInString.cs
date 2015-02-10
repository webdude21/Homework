// Write a program that reads a string from the console and lists all different words 
// in the string along with information how many times each word is found.
namespace CountWordsInString
{
    using System;
    using System.Collections.Generic;

    internal class PrintStringInfo
    {
        private static void Main()
        {
            var input =
                "Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.";
            char[] delimiters = { '.', '-', ',', ';', '?', '!', ' ' };
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var wordList = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (wordList.ContainsKey(word))
                {
                    wordList[word]++;
                }
                else
                {
                    wordList[word] = 1;
                }
            }

            foreach (var word in wordList)
            {
                Console.WriteLine("The word \"{0}\" is found {1} time(s)", word.Key, word.Value);
            }
        }
    }
}