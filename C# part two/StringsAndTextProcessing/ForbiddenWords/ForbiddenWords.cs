// We are given a string containing a list of forbidden words and a text containing some of these words. 
// Write a program that replaces the forbidden words with asterisks. Example:
namespace ForbiddenWords
{
    using System;
    using System.Text.RegularExpressions;

    internal class ForbiddenWords
    {
        private static void Main()
        {
            var input =
                "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
            var forbiddenWordsList = "PHP, CLR, Microsoft";
            Console.WriteLine(MaskForbiddenWords(input, forbiddenWordsList));
        }

        private static string MaskForbiddenWords(string input, string forbiddenWordsList)
        {
            // This methods replaces the words in the forbidden list with asterisks
            var result = input;
            var forbiddenWords = forbiddenWordsList.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < forbiddenWords.Length; i++)
            {
                result = Regex.Replace(result, @"\b" + forbiddenWords[i].Trim() + @"\b", k => new string('*', k.Length));
            }

            return result;
        }
    }
}