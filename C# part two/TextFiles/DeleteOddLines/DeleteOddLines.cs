// Write a program that deletes from given text file all odd lines. The result should be in the same file.

using System;
using System.IO;

class DeleteOddLines
{
    static void Main()
    {
        StreamReader inputFile = new StreamReader(@"..\..\inputFile.txt");
        StreamWriter outputFile = new StreamWriter(@"..\..\temp.txt");
        bool flip = true;
        using (inputFile)
        {
            using (outputFile)
            {
                string line = inputFile.ReadLine();
                while (line != null)
                {
                    if (!flip)
                    {
                        outputFile.WriteLine(line);
                        flip = !flip;
                    }
                    else
                    {
                        flip = !flip;
                    }
                    line = inputFile.ReadLine();
                }
            }
        }

        // Overwrite the old file and delete the temporary one
        File.Delete(@"..\..\inputFile.txt");
        File.Move(@"..\..\temp.txt", @"..\..\inputFile.txt");

        Console.WriteLine("Every odd line has been deleted in the file ");
    }
}