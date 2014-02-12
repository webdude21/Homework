// Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. Example:

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class ExtractTitleBodyFromHTML
{
    static void Main()
    {
        string input = @"<html><head><title>News</title></head><body><p><a href=\""http://academy.telerik.com\"">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body></html>";
        string pattern = @"(?<=>)[^\s*][^><]+(?=<)";

        MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.IgnorePatternWhitespace);

        for (int i = 0; i < matches.Count; i++)
        {
            if (i == 0)
            {
                Console.WriteLine("The Title is: {0}", matches[i]);
                Console.Write("The body is: ");
            }
            else
            {
                Console.WriteLine(matches[i]);
            }
        }
    }
}