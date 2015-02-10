// Write a program that reads a text file and prints on the console its odd lines.
namespace PrintFileOddLines
{
    using System;
    using System.IO;

    internal class PrintFileOddLines
    {
        private static void Main()
        {
            var stream = new StreamReader(@"..\..\PrintOddLines.txt");
            var flip = true;
            using (stream)
            {
                var line = stream.ReadLine();
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
}