// Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.
namespace SortListOfString
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class SortListOfString
    {
        private static void Main()
        {
            var inputFile = new StreamReader(@"..\..\inputFile.txt");
            var outputFile = new StreamWriter(@"..\..\output.txt");

            using (inputFile)
            {
                var currentLine = inputFile.ReadLine();
                var listToSort = new List<string>();

                while (currentLine != null)
                {
                    // This fills the list with the input
                    listToSort.Add(currentLine);
                    currentLine = inputFile.ReadLine();
                }

                listToSort.Sort();

                using (outputFile)
                {
                    foreach (var word in listToSort)
                    {
                        outputFile.WriteLine(word);
                    }
                }
            }

            Console.WriteLine("The names list has been sorted and saved in the file 'output.txt'.");
        }
    }
}