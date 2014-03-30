/* Write a program that counts how many times each word from given text file words.txt appears in
 * it. The character casing differences should be ignored. The result words should be ordered by
 * their number of occurrences in the text. */

using System;
using System.Collections.Generic;
using System.IO;

namespace CountWordOccurence
{
    class CountWordOccurence
    {
        static void Main()
        {
            // get the input from words.txt, but if it doesn't exist fallback to the default text
            var input = File.Exists(@"..\..\words.txt") ? new StreamReader(@"..\..\words.txt").ReadToEnd()
                : "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?";

            char[] splitString = {' ', ',', '-', '?', '!', '.', '-', '–', '"', '\t'};

            var dict = new Dictionary<string, int>();

            foreach (var item in input.ToLower().Replace(Environment.NewLine,
                string.Empty).Split(splitString, StringSplitOptions.RemoveEmptyEntries))
            {
                if (dict.ContainsKey(item)) dict[item]++;
                else dict.Add(item, 1);
            }

            foreach (var item in dict)
                Console.WriteLine("{0} => {1} times", item.Key, item.Value);
        }
    }
}
