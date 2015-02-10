// Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
namespace TextInSubStrings
{
    using System;

    internal class TextInSubStrings
    {
        private static void Main()
        {
            // All of this is just to test if it works.
            var input =
                "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days";
            var subString = "in";

            var timesFound = FindSubstringInString(input, subString);

            Console.WriteLine("The substring \"{0}\" was found {1} time(s) in the text.", subString, timesFound);
        }

        private static int FindSubstringInString(string input, string subString)
        {
            // This is the method that does all of the work.
            input = input.ToUpper();
            subString = subString.ToUpper();
            var timesFound = -1;
            var startindex = -1;

            do
            {
                startindex = input.IndexOf(subString, startindex + 1);
                timesFound++;
            }
            while (startindex > -1);
            return timesFound;
        }
    }
}