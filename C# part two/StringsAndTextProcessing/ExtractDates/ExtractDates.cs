// Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. Display them in the standard date format for Canada.

using System;
using System.Globalization;
using System.Text.RegularExpressions;

class ExtractDates
{
    static void Main()
    {
        string pattern = @"\b(0[1-9]|[12][\d]|3[01]|\d).(0[1-9]|1[012]|\d)\.(19|20)[\d]{2}";
        string input = "Some dates can be written like so 1.2.2013 others can be written like so 01.05.2013, dates like 41.13.1813 will not be passed as valid.";
        MatchCollection matches = Regex.Matches(input, pattern);
        string dateFormat = "d.M.yyyy";

        foreach (Match date in matches)
        {
            string currentDate = (DateTime.ParseExact(date.ToString(), dateFormat, CultureInfo.InvariantCulture).ToString(new CultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
            Console.WriteLine(currentDate);
        }

        //         Assert position at a word boundary «\b»
        // Match the regular expression below and capture its match into backreference number 1 «(0[1-9]|[12][0-9]|3[01]|\d)»
        //    Match either the regular expression below (attempting the next alternative only if this one fails) «0[1-9]»
        //       Match the character “0” literally «0»
        //       Match a single character in the range between “1” and “9” «[1-9]»
        //    Or match regular expression number 2 below (attempting the next alternative only if this one fails) «[12][0-9]»
        //       Match a single character present in the list “12” «[12]»
        //       Match a single character in the range between “0” and “9” «[0-9]»
        //    Or match regular expression number 3 below (attempting the next alternative only if this one fails) «3[01]»
        //       Match the character “3” literally «3»
        //       Match a single character present in the list “01” «[01]»
        //    Or match regular expression number 4 below (the entire group fails if this one fails to match) «\d»
        //       Match a single digit 0..9 «\d»
        // Match any single character that is not a line break character «.»
        // Match the regular expression below and capture its match into backreference number 2 «(0[1-9]|1[012]|\d)»
        //    Match either the regular expression below (attempting the next alternative only if this one fails) «0[1-9]»
        //       Match the character “0” literally «0»
        //       Match a single character in the range between “1” and “9” «[1-9]»
        //    Or match regular expression number 2 below (attempting the next alternative only if this one fails) «1[012]»
        //       Match the character “1” literally «1»
        //       Match a single character present in the list “012” «[012]»
        //    Or match regular expression number 3 below (the entire group fails if this one fails to match) «\d»
        //       Match a single digit 0..9 «\d»
        // Match the character “.” literally «\.»
        // Match the regular expression below and capture its match into backreference number 3 «(19|20)»
        //    Match either the regular expression below (attempting the next alternative only if this one fails) «19»
        //       Match the characters “19” literally «19»
        //    Or match regular expression number 2 below (the entire group fails if this one fails to match) «20»
        //       Match the characters “20” literally «20»
        // Match a single character in the range between “0” and “9” «[0-9]{2}»
        //    Exactly 2 times «{2}»
    }
}
