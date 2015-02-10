// This task I did by mistake (by not reading the task itself correctly). I decided to leave it anyway
namespace CountWordsInAFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security;
    using System.Text.RegularExpressions;

    internal class CountWordsInAFile
    {
        private static void Main()
        {
            try
            {
                var input = ReadFileToString(@"..\..\inputFile.txt");
                WriteResultToFile(input, @"..\..\output.txt");
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

        private static void WriteResultToFile(string input, string filePath)
        {
            var outputFile = new StreamWriter(filePath);
            var words = GetWordsFromString(input);
            var uniqueWords = GetUniqueWordCount(words);

            using (outputFile)
            {
                foreach (var word in uniqueWords.OrderByDescending(key => key.Value))
                {
                    outputFile.WriteLine("{1} - {0}", word.Key, word.Value);
                }
            }
        }

        private static Dictionary<string, int> GetUniqueWordCount(string[] words)
        {
            // This methods gets only the unique words
            Array.Sort(words); // sort the array
            var wordUsedCount = new Dictionary<string, int>();
            var currentWord = string.Empty;
            var tempCount = 1;

            for (var word = 0; word < words.Length; word++)
            {
                if (currentWord != words[word])
                {
                    currentWord = words[word];
                    wordUsedCount.Add(words[word], tempCount);
                    tempCount = 1;
                }
                else
                {
                    tempCount++;
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
            // all of the "words" that are the result of the reggular expression
            // After that we go trough the collection and save it into an array so
            // it can be used later (you can acctuly return the MatchCollection itself, but 
            // I decided not to do so. \w+ means all of the words that are longer that or equal to one char.
            var words = Regex.Matches(input, @"\w+");
            var result = new string[words.Count];

            for (var i = 0; i < words.Count; i++)
            {
                result[i] = words[i].ToString();
            }

            return result;
        }
    }
}