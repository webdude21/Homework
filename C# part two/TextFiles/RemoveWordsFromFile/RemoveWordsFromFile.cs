// Write a program that removes from a text file all words listed in given another text file. Handle all possible exceptions in your methods.

using System;
using System.IO;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

class RemoveWordsFromFile
{
    static void Main()
    {
        try
        {
            string input = ReadFileToString(@"..\..\inputFile.txt");
            string wordsToRemove = ReadFileToString(@"..\..\removewords.txt");
            string output = RemoveWordsFromString(input, GetWordsFromString(wordsToRemove));
            WriteStringToFile(output, @"..\..\output.txt");
            // You can make it overwrite the original file if you uncomment the following line:
            // WriteStringToFile(output, @"..\..\inputFile.txt"); 

        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine(fnfe.Message);
        }

        catch (DirectoryNotFoundException dnfe)
        {
            Console.WriteLine(dnfe.Message);
        }

        catch (IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }

        catch (SecurityException se)
        {
            Console.WriteLine(se.Message);
        }

        catch (UnauthorizedAccessException eae)
        {
            Console.WriteLine(eae.Message);
        }

    }

    static string ReadFileToString(string filePath)
    {
        // this only reads file and saves it in a string
        StreamReader inputFile = new StreamReader(filePath);

        using (inputFile)
        {
            return inputFile.ReadToEnd();
        }
    }

    static string[] GetWordsFromString(string input)
    {
        // This creates a new object MatchCollection that contains
        // all of the "words" that are the result of the reggular expression
        // After that we go trough the collection and save it into an array so
        // it can be used later (you can acctuly return the MatchCollection itself, but 
        // I decided not to do so. \w+ means all of the words that are longer that or equal to one char.

        MatchCollection words = Regex.Matches(input, @"\w+");
        string[] result = new string[words.Count];

        for (int i = 0; i < words.Count; i++)
        {
            result[i] = words[i].ToString();
        }

        return result;
    }

    static string RemoveWordsFromString(string input, string[] stringsToRemove)
    {
        // This removes the words that are in the string array
        string result = input;
        foreach (string word in stringsToRemove)
        {
            result = result.Replace(word, string.Empty);
        }

        return result;
    }

    static void WriteStringToFile(string stringOutput, string filePath)
    {
        // This only saves the string to a text file
        StreamWriter output = new StreamWriter(filePath);

        using (output)
        {
            output.Write(stringOutput);
        }
    }
}
