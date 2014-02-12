// Write a program that replaces all occurrences of the substring "start" with the substring "finish" 
// in a text file. Ensure it will work with large files (e.g. 100 MB).
// Modify the solution of the previous problem to replace only whole words (not substrings).


using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceWordsInFile
{
    static void Main()
    {
        // Create a temp file since I cannot read and write at the same time using the same file.
        StreamReader inputFile = new StreamReader(@"..\..\inputFile.txt");
        StreamWriter outputFile = new StreamWriter(@"..\..\temp.txt");

        string currentLine = " ";

        using (inputFile)
        {
            using (outputFile)
            {
                while (currentLine != null)
                {
                    currentLine = inputFile.ReadLine();
                    if (currentLine != null)
                    {
                        outputFile.WriteLine(Regex.Replace(currentLine, @"\bstart\b", "finish"));
                    }
                }
            }

        }

        // Overwrite the old file and delete the temporary one
        File.Delete(@"..\..\inputFile.txt");
        File.Move(@"..\..\temp.txt", @"..\..\inputFile.txt");

        Console.WriteLine("Every word 'start' has been replace by the word 'finish'.");
    }
}