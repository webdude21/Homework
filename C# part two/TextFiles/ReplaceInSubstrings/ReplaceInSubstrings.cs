// Write a program that replaces all occurrences of the substring "start" with the substring "finish" 
// in a text file. Ensure it will work with large files (e.g. 100 MB).


using System;
using System.Text;
using System.IO;

class ReplaceInSubstrings
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
                        outputFile.WriteLine(currentLine.Replace("start", "finish"));
                    }
                }
            }

        }

        // Overwrite the old file and delete the temporary one
        File.Delete(@"..\..\inputFile.txt");
        File.Move(@"..\..\temp.txt", @"..\..\inputFile.txt");

        Console.WriteLine("Every 'start' has been replace by 'finish'.");
    }
}