// Write a program that concatenates two text files into another text file.

using System;
using System.IO;
using System.Text;

class ConcatenatesTwoFiles
{
    static void Main()
    {
        StreamReader fileOne = new StreamReader(@"..\..\fileOne.txt");
        StreamReader fileTwo = new StreamReader(@"..\..\fileTwo.txt");
        StreamWriter outputFile = new StreamWriter(@"..\..\output.txt");

        using (fileOne)
        {
            using (fileTwo)
            {
                using (outputFile)
                {
                    string fileOneText = fileOne.ReadToEnd();
                    string fileTwoText = fileTwo.ReadToEnd();
                    outputFile.Write("{0}\r\n{1}", fileOneText, fileTwoText);
                    Console.WriteLine("The two files have been merged");
                }
            }
        }
    }
}