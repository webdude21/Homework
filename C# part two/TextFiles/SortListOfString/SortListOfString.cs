// Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class SortListOfString
{
    static void Main()
    {
        StreamReader inputFile = new StreamReader(@"..\..\inputFile.txt");
        StreamWriter outputFile = new StreamWriter(@"..\..\output.txt");

        using (inputFile)
        {
            string currentLine = inputFile.ReadLine();
            List<string> listToSort = new List<string>();

            while (currentLine != null)
            {
                // This fills the list with the input
                listToSort.Add(currentLine);
                currentLine = inputFile.ReadLine();
            }

            listToSort.Sort();

            using (outputFile)
            {
                foreach (string word in listToSort)
                {
                    outputFile.WriteLine(word);
                }
            }
        }

        Console.WriteLine("The names list has been sorted and saved in the file 'output.txt'.");
    }
}
