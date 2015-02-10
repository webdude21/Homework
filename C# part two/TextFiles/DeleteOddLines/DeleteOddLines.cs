// Write a program that deletes from given text file all odd lines. The result should be in the same file.
namespace DeleteOddLines
{
    using System;
    using System.IO;

    internal class DeleteOddLines
    {
        private static void Main()
        {
            var inputFile = new StreamReader(@"..\..\inputFile.txt");
            var outputFile = new StreamWriter(@"..\..\temp.txt");
            var flip = true;
            using (inputFile)
            {
                using (outputFile)
                {
                    var line = inputFile.ReadLine();
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
}