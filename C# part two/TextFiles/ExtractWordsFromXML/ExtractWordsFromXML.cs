// Write a program that extracts from given XML file all the text without the tags. Example:
namespace ExtractWordsFromXML
{
    using System;
    using System.IO;
    using System.Text;

    internal class ExtractWordsFromXML
    {
        private static void Main()
        {
            ExtractTextToFile(GetInputFromFile());
            Console.WriteLine("All of the text has been and saved to 'output.txt'");
        }

        private static void ExtractTextToFile(string fileContent)
        {
            // Here I try to find text and put it in the output file
            var output = new StreamWriter("../../output.txt");
            using (output)
            {
                var currStr = new StringBuilder();
                for (var currChar = 0; currChar < fileContent.Length - 2; currChar++)
                {
                    if (fileContent[currChar] == '>' && fileContent[currChar + 1] != '<')
                    {
                        currChar++;
                        while (fileContent[currChar] != '<')
                        {
                            currStr.Append(fileContent[currChar]);
                            currChar++;
                        }

                        if (!string.IsNullOrWhiteSpace(currStr.ToString()))
                        {
                            output.WriteLine(currStr);
                        }

                        currStr.Clear();
                    }
                }
            }
        }

        private static string GetInputFromFile()
        {
            // Read the entire input and get rid of new lines
            var input = new StreamReader("../../inputFile.xml");
            string fileContent = null;
            using (input)
            {
                fileContent = input.ReadToEnd();
                fileContent = fileContent.Replace(Environment.NewLine, string.Empty);
            }

            return fileContent;
        }
    }
}