// Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;

class PrintFileOddLines
{
    static void Main()
    {
        StreamReader stream = new StreamReader(@"..\..\PrintOddLines.txt");
        bool flip = true;
        using (stream)
        {
            string line = stream.ReadLine();
            while (line != null)
            {
                if (!flip)
                {
                    Console.WriteLine(line);
                    flip = !flip;
                }
                else
                {
                    flip = !flip;
                }
                line = stream.ReadLine();
            }
        }
    }
}