// Write a program that concatenates two text files into another text file.
namespace ConcatenatesTwoFiles
{
    using System;
    using System.IO;

    internal class ConcatenatesTwoFiles
    {
        private static void Main()
        {
            var fileOne = new StreamReader(@"..\..\fileOne.txt");
            var fileTwo = new StreamReader(@"..\..\fileTwo.txt");
            var outputFile = new StreamWriter(@"..\..\output.txt");

            using (fileOne)
            {
                using (fileTwo)
                {
                    using (outputFile)
                    {
                        var fileOneText = fileOne.ReadToEnd();
                        var fileTwoText = fileTwo.ReadToEnd();
                        outputFile.Write("{0}\r\n{1}", fileOneText, fileTwoText);
                        Console.WriteLine("The two files have been merged");
                    }
                }
            }
        }
    }
}