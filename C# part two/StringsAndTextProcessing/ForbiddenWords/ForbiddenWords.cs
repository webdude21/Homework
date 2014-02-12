// We are given a string containing a list of forbidden words and a text containing some of these words. 
// Write a program that replaces the forbidden words with asterisks. Example:

using System;
using System.Text.RegularExpressions;
using System.Text;

class ForbiddenWords
{
    static void Main()
    {
        string input = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string forbiddenWordsList = "PHP, CLR, Microsoft";
        Console.WriteLine(MaskForbiddenWords(input, forbiddenWordsList));
    }

    static string MaskForbiddenWords(string input, string forbiddenWordsList)
    {   // This methods replaces the words in the forbidden list with asterisks
        string result = input;
        string[] forbiddenWords = forbiddenWordsList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < forbiddenWords.Length; i++)
        {
            result = Regex.Replace(result, @"\b" + forbiddenWords[i].Trim() + @"\b", k => new string('*', k.Length));
        }
        return result;
    }
}
