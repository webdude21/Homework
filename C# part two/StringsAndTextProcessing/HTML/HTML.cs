// Write a program that replaces in a HTML document given as string all the tags 
// <a href="…">…</a> with corresponding tags [URL=…]…/URL]. Sample HTML fragment:

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class HTML
{
    static void Main()
    {
        string input = "<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
        MatchCollection matches = Regex.Matches(input, @"(?<href><\s*a\s*href\s*=)[^>]*(?<cls>""\s*>)[^<]*(?<atag><s*/s*as*>)", RegexOptions.IgnoreCase);
        string output = input;
        foreach (Match match in matches)
        {
            output = Regex.Replace(output, match.Groups["href"].Value, "[URL=");
            output = Regex.Replace(output, match.Groups["atag"].Value, "[/URL]");
            output = Regex.Replace(output, match.Groups["cls"].Value, "\"]");

        }
        Console.WriteLine(output);

        //   This is the explination on the following regex: (?<href><\s*a\s*href\s*=)[^>]*(?<cls>"\s*>)[^<]*(?<atag><s*/s*as*>)
        // Match the regular expression below and capture its match into backreference with name “href” «(?<href><\s*a\s*href\s*=)»
        //    Match the character “<” literally «<»
        //    Match a single character that is a “whitespace character” (spaces, tabs, line breaks, etc.) «\s*»
        //       Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
        //    Match the character “a” literally «a»
        //    Match a single character that is a “whitespace character” (spaces, tabs, line breaks, etc.) «\s*»
        //       Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
        //    Match the characters “href” literally «href»
        //    Match a single character that is a “whitespace character” (spaces, tabs, line breaks, etc.) «\s*»
        //       Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
        //    Match the character “=” literally «=»
        // Match any character that is NOT a “>” «[^>]*»
        //    Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
        // Match the regular expression below and capture its match into backreference with name “cls” «(?<cls>"\s*>)»
        //    Match the character “"” literally «"»
        //    Match a single character that is a “whitespace character” (spaces, tabs, line breaks, etc.) «\s*»
        //       Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
        //    Match the character “>” literally «>»
        // Match any character that is NOT a “<” «[^<]*»
        //    Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
        // Match the regular expression below and capture its match into backreference with name “atag” «(?<atag><s*/s*as*>)»
        //    Match the character “<” literally «<»
        //    Match the character “s” literally «s*»
        //       Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
        //    Match the character “/” literally «/»
        //    Match the character “s” literally «s*»
        //       Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
        //    Match the character “a” literally «a»
        //    Match the character “s” literally «s*»
        //       Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
        //    Match the character “>” literally «>»
    }
}