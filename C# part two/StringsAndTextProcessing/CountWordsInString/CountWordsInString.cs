// Write a program that reads a string from the console and lists all different words 
// in the string along with information how many times each word is found.


using System;
using System.Collections.Generic;

class PrintStringInfo
{
    static void Main()
    {
        string input = "Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.";
        char[] delimiters = { '.', '-', ',', ';', '?', '!', ' ' };
        string[] words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> wordList = new Dictionary<string, int>();

        foreach (string word in words)
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