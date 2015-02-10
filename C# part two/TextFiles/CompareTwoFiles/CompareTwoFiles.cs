// Write a program that compares two text files line by line and prints the number of lines that are the
// same and the number of lines that are different. Assume the files have equal number of lines.
namespace CompareTwoFiles
{
    using System;
    using System.IO;

    internal class CompareTwoFiles
    {
        private static void Main()
        {
            var fileOne = new StreamReader(@"..\..\fileOne.txt");
            var fileTwo = new StreamReader(@"..\..\fileTwo.txt");

            using (fileOne)
            {
                using (fileTwo)
                {
                    var fileOneLine = fileOne.ReadLine();
                    var fileTwoLine = fileTwo.ReadLine();
                    var currentLine = 0;
                    var matchingLines = 0;

                    while (fileOneLine != null || fileTwoLine != null)
                    {
                        currentLine++;
                        if (fileTwoLine == fileOneLine)
                        {
                            matchingLines++;
                        }

                        fileOneLine = fileOne.ReadLine();
                        fileTwoLine = fileTwo.ReadLine();
                    }

                    Console.WriteLine(
                        "There are {0} line(s) that are the same and {1} that are different", 
                        matchingLines, 
                        currentLine - matchingLines);
                }
            }
        }
    }
}