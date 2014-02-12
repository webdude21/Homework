// Write a program that compares two text files line by line and prints the number of lines that are the
// same and the number of lines that are different. Assume the files have equal number of lines.

using System;
using System.IO;
using System.Text;

class CompareTwoFiles
{
    static void Main()
    {
        StreamReader fileOne = new StreamReader(@"..\..\fileOne.txt");
        StreamReader fileTwo = new StreamReader(@"..\..\fileTwo.txt");

        using (fileOne)
        {
            using (fileTwo)
            {
                string fileOneLine = fileOne.ReadLine();
                string fileTwoLine = fileTwo.ReadLine();
                int currentLine = 0;
                int matchingLines = 0;

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
                Console.WriteLine("There are {0} line(s) that are the same and {1} that are different", matchingLines, currentLine - matchingLines);
            }
        }
    }
}
