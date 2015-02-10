// Write a program that replaces all occurrences of the substring "start" with the substring "finish" 
// in a text file. Ensure it will work with large files (e.g. 100 MB).
namespace ReplaceInSubstrings
{
    using System;
    using System.IO;

    internal class ReplaceInSubstrings
    {
        private static void Main()
        {
            // Create a temp file since I cannot read and write at the same time using the same file.
            var inputFile = new StreamReader(@"..\..\inputFile.txt");
            var outputFile = new StreamWriter(@"..\..\temp.txt");

            var currentLine = " ";

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
}