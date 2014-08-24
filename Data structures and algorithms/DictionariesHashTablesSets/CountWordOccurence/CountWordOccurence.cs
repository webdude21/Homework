/* Write a program that counts how many times each word from given text file words.txt appears in
 * it. The character casing differences should be ignored. The result words should be ordered by
 * their number of occurrences in the text. */
namespace CountWordOccurence
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class CountWordOccurence
    {
        private static void Main()
        {
            // get the input from words.txt, but if it doesn't exist fallback to the default text
            var input = File.Exists(@"..\..\words.txt")
                            ? new StreamReader(@"..\..\words.txt").ReadToEnd()
                            : "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?";

            char[] splitString = { ' ', ',', '-', '?', '!', '.', '-', '–', '"', '\t' };

            var dict = new Dictionary<string, int>();
            var wordsWithoutDelimiters = input.ToLower()
                .Replace(Environment.NewLine, string.Empty)
                .Split(splitString, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in wordsWithoutDelimiters)
            {
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }
                else
                {
                    dict.Add(word, 1);
                }
            }

            foreach (var word in dict)
            {
                Console.WriteLine("{0} => {1} times", word.Key, word.Value);
            }
        }
    }
}