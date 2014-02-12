// Write a program that reads a list of words from a file words.txt and finds how many times each of the words is 
// contained in another file test.txt. The result should be written in the file result.txt and the words should be 
// sorted by the number of their occurrences in descending order. Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

class CountAllWordsFromAFile
{
    static void Main()
    {
        try
        {
            string test = ReadFileToString(@"..\..\test.txt");
            string wordList = ReadFileToString(@"..\..\words.txt");
            Dictionary<string, int> wordUsedCount = GetUniqueWordCount(GetWordsFromString(wordList), GetWordsFromString(test));
            WriteResultToFile(wordUsedCount, @"..\..\result.txt");

        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine(fnfe.Message);
        }

        catch (DirectoryNotFoundException dnfe)
        {
            Console.WriteLine(dnfe.Message);
        }

        catch (IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }

        catch (SecurityException se)
        {
            Console.WriteLine(se.Message);
        }

        catch (UnauthorizedAccessException eae)
        {
            Console.WriteLine(eae.Message);
        }

    }

    static Dictionary<string, int> GetUniqueWordCount(string[] words, string[] input)
    {
        //This methods gets only the unique words
        Array.Sort(input);
        Array.Sort(words);
        Dictionary<string, int> wordUsedCount = new Dictionary<string, int>();
        string currentWord = string.Empty;
        int tempCount = 0;

        // The main loop is the one with the wordlist and the nested one is with the words from the test file.
        for (int wrd = 0; wrd < words.Length; wrd++)
        {
            currentWord = words[wrd];
            for (int index = 0; index < input.Length; index++)
            {
                if (currentWord == input[index])
                {
                    tempCount++;
                }
            }
            if (tempCount > 0)
            {
                wordUsedCount.Add(currentWord, tempCount);
                tempCount = 0;
            }
        }

        return wordUsedCount;
    }

    static string ReadFileToString(string filePath)
    {
        // this only reads file and saves it in a string
        StreamReader inputFile = new StreamReader(filePath);

        using (inputFile)
        {
            return inputFile.ReadToEnd();
        }
    }

    static string[] GetWordsFromString(string input)
    {
        // This creates a new object MatchCollection that contains
        // all of the "words" that are the result of the regular expression
        // After that we go trough the collection and save it into an array so
        // it can be used later (you can actually return the MatchCollection itself, but 
        // I decided not to do so. \w+ means all of the words that are longer that or equal to one char.

        MatchCollection words = Regex.Matches(input, @"\w+");
        string[] result = new string[words.Count];

        for (int i = 0; i < words.Count; i++)
        {
            result[i] = words[i].ToString();
        }

        return result;
    }

    static void WriteResultToFile(Dictionary<string, int> countedWords, string filePath)
    {   
        // Here I traverse the countedWords array in descending order and write them to the file.
        StreamWriter outputFile = new StreamWriter(filePath);

        using (outputFile)
        {
            foreach (KeyValuePair<string, int> word in countedWords.OrderByDescending(key => key.Value))
            {
                outputFile.WriteLine("{1} - {0}", word.Key, word.Value);
            }
        }
    }
}