// Write a program that reverses the words in given sentence.
// Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".
namespace ReverseWordsInSentence
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class ReverseWordsInSentence
    {
        private static void Main()
        {
            var input = "C# is not C++, not PHP and not Delphi!";
            char[] delimiters = { '.', '-', ',', ';', '?', '!', ' ' };
            var delimitersInSentance = new Queue<string>();
            var wordsInSentance = new Stack<string>();
            var result = new StringBuilder();

            // Here's the most interesting part I think ...
            // This one I decided to do without regex because it seemd like an overkill
            // Here I split the sentence and get the words, and then split the sentance using 
            // the words as delimiters so I can get the real delimiters :)
            var wordsInSentence = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var delimitersInSentence = input.Split(wordsInSentence, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in wordsInSentence)
            {
                wordsInSentance.Push(word);
            }

            foreach (var del in delimitersInSentence)
            {
                delimitersInSentance.Enqueue(del);
            }

            while (delimitersInSentance.Count > 0 && wordsInSentance.Count > 0)
            {
                result.Append(wordsInSentance.Pop());
                result.Append(delimitersInSentance.Dequeue());
            }

            Console.WriteLine(result);
        }
    }
}