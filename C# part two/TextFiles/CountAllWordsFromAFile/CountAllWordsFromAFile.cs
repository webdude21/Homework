// Write a program that reads a list of words from a file words.txt and finds how many times each of the words is 
// contained in another file test.txt. The result should be written in the file result.txt and the words should be 
// sorted by the number of their occurrences in descending order. Handle all possible exceptions in your methods.
namespace CountAllWordsFromAFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security;
    using System.Text.RegularExpressions;

    internal class CountAllWordsFromAFile
    {
        private static void Main()
        {
            try
            {
                var test = ReadFileToString(@"..\..\test.txt");
                var wordList = ReadFileToString(@"..\..\words.txt");
                var wordUsedCount = GetUniqueWordCount(GetWordsFromString(wordList), GetWordsFromString(test));
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

        private static Dictionary<string, int> GetUniqueWordCount(string[] words, string[] input)
        {
            // This methods gets only the unique words
            Array.Sort(input);
            Array.Sort(words);
            var wordUsedCount = new Dictionary<string, int>();
            var currentWord = string.Empty;
            var tempCount = 0;

            // The main loop is the one with the wordlist and the nested one is with the words from the test file.
            foreach (var word in words)
            {
                currentWord = word;
                tempCount += input.Count(t1 => currentWord == t1);

                if (tempCount > 0)
                {
                    wordUsedCount.Add(currentWord, tempCount);
                    tempCount = 0;
                }
            }

            return wordUsedCount;
        }

        private static string ReadFileToString(string filePath)
        {
            // this only reads file and saves it in a string
            var inputFile = new StreamReader(filePath);

            using (inputFile)
            {
                return inputFile.ReadToEnd();
            }
        }

        private static string[] GetWordsFromString(string input)
        {
            // This creates a new object MatchCollection that contains
            // all of the "words" that are the result of the regular expression
            // After that we go trough the collection and save it into an array so
            // it can be used later (you can actually return the MatchCollection itself, but 
            // I decided not to do so. \w+ means all of the words that are longer that or equal to one char.
            var words = Regex.Matches(input, @"\w+");
            var result = new string[words.Count];

            for (var i = 0; i < words.Count; i++)
            {
                result[i] = words[i].ToString();
            }

            return result;
        }

        private static void WriteResultToFile(Dictionary<string, int> countedWords, string filePath)
        {
            // Here I traverse the countedWords array in descending order and write them to the file.
            var outputFile = new StreamWriter(filePath);

            using (outputFile)
            {
                foreach (var word in countedWords.OrderByDescending(key => key.Value))
                {
                    outputFile.WriteLine("{1} - {0}", word.Key, word.Value);
                }
            }
        }
    }
}