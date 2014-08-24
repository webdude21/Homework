/* Write a program that finds a set of words (e.g. 1000 words) in a large text 
 * (e.g. 100 MB text file). Print how many times each word occurs in the text. 
 * Hint: you may find a C# trie in Internet.*/
namespace Trie
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    using Trie.rmandvikar.Trie;

    internal class TrieTest
    {
        private static readonly string[] SplitChars =
            {
                ",", "\"", "'", " ", "!", "-", ".", "?", ":", ";", "[", "]", "(", 
                ")", "\n", Environment.NewLine
            };

        private static IEnumerable<string> ReadWordsFromFile()
        {
            using (var input = new StreamReader("../../big.txt"))
            {
                return input.ReadToEnd().ToLowerInvariant().Split(SplitChars, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private static void Main()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var wordArray = ReadWordsFromFile();
            Console.WriteLine("Time taken to load the file {0}", stopWatch.Elapsed);
            stopWatch.Restart();
            var trieStructure = TrieFactory.GetTrie();

            foreach (var word in wordArray)
            {
                trieStructure.AddWord(word);
            }

            Console.WriteLine("Time taken to put words in the TRIE structure {0}", stopWatch.Elapsed);
            stopWatch.Restart();

            var searchArray = new[] { "Sherlock", "when", "about", "and", "said", "ago" };
            Console.WriteLine(
                string.Join(
                    " - ", 
                    searchArray.Select(
                        word => string.Format("{0} {1}", word, trieStructure.WordCount(word.ToLowerInvariant())))));
            Console.WriteLine("Time taken to do the search {0}", stopWatch.Elapsed);
        }
    }
}