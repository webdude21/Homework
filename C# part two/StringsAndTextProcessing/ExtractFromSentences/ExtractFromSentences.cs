// Write a program that extracts from a given text all sentences containing given word.
// Consider that the sentences are separated by "." and the words – by non-letter symbols.
namespace ExtractFromSentences
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class ExtractFromSentences
    {
        private static void Main()
        {
            var input =
                "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            var word = "in";
            var result = GetSentencesThatContainWord(input, word);

            Console.WriteLine(result);
        }

        private static string GetSentencesThatContainWord(string input, string word)
        {
            // The regular expression allows us to only select whole words.
            // \b means word boundary
            var sentances = input.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            var expression = new Regex(@"\b" + word + @"\b");
            var result = new StringBuilder();

            for (var i = 0; i < sentances.Length; i++)
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
}