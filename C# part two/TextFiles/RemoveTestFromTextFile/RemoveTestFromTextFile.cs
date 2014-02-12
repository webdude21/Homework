// Write a program that reads a list of words from a file words.txt and finds how many times each of the words is 
// contained in another file test.txt. The result should be written in the file result.txt and the words should be 
// sorted by the number of their occurrences in descending order. Handle all possible exceptions in your methods.


using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class RemoveTestFromTextFile
{
    static void Main()
    {
        StreamReader inputFile = new StreamReader(@"..\..\inputFile.txt");
        string fileContent;

        using (inputFile)
        {
            fileContent = inputFile.ReadToEnd();
        }
        // I've used regular expressions here since i've realized that this is somethign I must learn to use
        fileContent = Regex.Replace(fileContent, @"\b(test\w+)", "");
        StreamWriter outputFile = new StreamWriter(@"..\..\inputFile.txt");
        using (outputFile)
        {
            outputFile.Write(fileContent);
        }

        Console.WriteLine("Test has been revomved from all words that begin with it");
    }
}