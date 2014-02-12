// Write a program for extracting all email addresses from given text. 
// All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.

using System;
using System.Text.RegularExpressions;

class ExtractEmail
{
    static void Main()
    {
        string pattern = @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,5}\b";
        string input = "Something something Darthmall@deathstar.com, something something darkside@force.co.uk";
        MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
        foreach (Match match in matches)
        {
            Console.WriteLine(match);
        }

        //         Assert position at a word boundary «\b»
        // Match a single character present in the list below «[A-Z0-9._%+-]+»
        //    Between one and unlimited times, as many times as possible, giving back as needed (greedy) «+»
        //    A character in the range between “A” and “Z” «A-Z»
        //    A character in the range between “0” and “9” «0-9»
        //    One of the characters “._%” «._%»
        //    The character “+” «+»
        //    The character “-” «-»
        // Match the character “@” literally «@»
        // Match a single character present in the list below «[A-Z0-9.-]+»
        //    Between one and unlimited times, as many times as possible, giving back as needed (greedy) «+»
        //    A character in the range between “A” and “Z” «A-Z»
        //    A character in the range between “0” and “9” «0-9»
        //    The character “.” «.»
        //    The character “-” «-»
        // Match the character “.” literally «\.»
        // Match a single character in the range between “A” and “Z” «[A-Z]{2,4}»
        //    Between 2 and 4 times, as many times as possible, giving back as needed (greedy) «{2,4}»
        // Assert position at a word boundary «\b»
    }
}