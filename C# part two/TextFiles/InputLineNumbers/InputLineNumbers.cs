// Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file.
namespace InputLineNumbers
{
    using System;
    using System.IO;

    internal class InputLineNumbers
    {
        private static void Main()
        {
            var inputFile = new StreamReader(@"..\..\LorenIpsum.txt");
            var outputFile = new StreamWriter(@"..\..\output.txt");

            using (inputFile)
            {
                using (outputFile)
                {
                    var currentLine = inputFile.ReadLine();
                    var lineNumber = 0;

                    while (currentLine != null)
                    {
                        lineNumber++; // Increase the line number

                        // Write the current line to the output file
                        outputFile.WriteLine("Line {0}: {1}", lineNumber, currentLine);

                        // Read the next line until there are no more lines left
                        currentLine = inputFile.ReadLine();
                    }

                    Console.WriteLine(
                        "Line numbers have been added to the input file \r\nand the result was saved into output.txt");
                }
            }
        }
    }
}