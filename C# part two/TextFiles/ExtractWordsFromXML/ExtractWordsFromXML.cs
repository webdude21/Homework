// Write a program that extracts from given XML file all the text without the tags. Example:

using System;
using System.IO;
using System.Text;

class ExtractWordsFromXML
{
    static void Main()
    {
        ExtractTextToFile(GetInputFromFile());
        Console.WriteLine("All of the text has been and saved to 'output.txt'");
    }

    static void ExtractTextToFile(string fileContent)
    {
        // Here I try to find text and put it in the output file
        StreamWriter output = new StreamWriter("../../output.txt");
        using (output)
        {
            StringBuilder currStr = new StringBuilder();
            for (int currChar = 0; currChar < fileContent.Length - 2; currChar++)
            {
                if (fileContent[currChar] == '>' && fileContent[currChar + 1] != '<')
                {
                    currChar++;
                    while (fileContent[currChar] != '<')
                    {
                        currStr.Append(fileContent[currChar]);
                        currChar++;
                    }
                    if (!String.IsNullOrWhiteSpace(currStr.ToString()))
                    {
                        output.WriteLine(currStr);
                    }
                    currStr.Clear();
                }
            }
        }
    }

    static string GetInputFromFile()
    {
        // Read the entire input and get rid of new lines
        StreamReader input = new StreamReader("../../inputFile.xml");
        string fileContent = null;
        using (input)
        {
            fileContent = input.ReadToEnd();
            fileContent = fileContent.Replace(System.Environment.NewLine, "");
        }

        return fileContent;
    }
}