// Write a program that extracts from a given text all sentences containing given word.
// Consider that the sentences are separated by "." and the words – by non-letter symbols.

using System;
using System.Text.RegularExpressions;
using System.Text;

class ExtractFromSentences
{
    static void Main()
    {
        string input = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string word = "in";
        string result = GetSentencesThatContainWord(input, word);

        Console.WriteLine(result);
    }

    static string GetSentencesThatContainWord(string input, string word)
    {   // The regular expression allows us to only select whole words.
        // \b means word boundary
        string[] sentances = input.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
        Regex expression = new Regex(@"\b" + word + @"\b");
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < sentances.Length; i++)
        {
            if (expression.IsMatch(sentances[i]))
            {
                result.Append(sentances[i]);
                result.Append('.');
            }
        }
        return result.ToString();
    }
}
