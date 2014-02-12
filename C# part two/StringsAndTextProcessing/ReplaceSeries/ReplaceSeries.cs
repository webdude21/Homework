// Write a program that reads a string from the console and replaces all series of consecutive 
// identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".

using System;
using System.Text.RegularExpressions;

class ReplaceSeries
{
    static void Main()
    {
        string input = "aaaaabbbbbcdddeeeedssaa";
        Console.WriteLine("The result is: {0}", Regex.Replace(input, @"(.)\1+", "$1"));

        // Match the regular expression below and capture its match into backreference number 1 «(.)»
        //    Match any single character that is not a line break character «.»
        // Match the same text as most recently matched by capturing group number 1 «\1+»
        //    Between one and unlimited times, as many times as possible, giving back as needed (greedy) «+»
    }
}