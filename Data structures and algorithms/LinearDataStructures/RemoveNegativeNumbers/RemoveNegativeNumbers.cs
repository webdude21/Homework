// Write a program that removes from given sequence all negative numbers

using System;
using System.Collections.Generic;
using System.IO;

namespace RemoveNegativeNumbers
{
    class RemoveNegativeNumbers
    {
        static void Main()
        {
            var numberSequence = ReadInput();
            numberSequence.RemoveAll(number => number < 0);
            Console.WriteLine(string.Join(", ", numberSequence));
        }
        private static List<int> ReadInput()
        {
            Console.SetIn(new StreamReader(@"..\..\input.txt"));
            var numbers = new List<int>();
            var currentLine = Console.ReadLine();

            while (currentLine != null)
            {
                numbers.Add(int.Parse(currentLine));
                currentLine = Console.ReadLine();
            }
            return numbers;
        }
    }
}
