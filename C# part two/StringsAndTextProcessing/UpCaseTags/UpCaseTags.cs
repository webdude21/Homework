// You are given a text. Write a program that changes the text in all regions surrounded by the tags 
// <upcase> and </upcase> to uppercase. The tags cannot be nested. Example:

using System;
using System.Text;
using System.Text.RegularExpressions;

class UpCaseTags
{
    static void Main()
    {
        // To anyone reading this that doesn't understand it, I've used regular expressions. I'm fairly new at it, but I've
        // decided to give it a try.

        string input = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        Regex expression = new Regex(@"<upcase>(?<toUp>[^<]+)</upcase>", RegexOptions.IgnoreCase);
        string output = expression.Replace(input, k => k.Groups["toUp"].Value.ToUpper());
        Console.WriteLine(output);

        // Here's the explination of the expression "<upcase>(?<toUp>[^<]+)</upcase>"
        // Match the characters “<upcase>” literally «<upcase>»
        // Match the regular expression below and capture its match into backreference with name “toUp” «(?<toUp>[^<]+)»
        //    Match any character that is NOT a “<” «[^<]+»
        //       Between one and unlimited times, as many times as possible, giving back as needed (greedy) «+»
        // Match the characters “</upcase>” literally «</upcase>»
    }
}