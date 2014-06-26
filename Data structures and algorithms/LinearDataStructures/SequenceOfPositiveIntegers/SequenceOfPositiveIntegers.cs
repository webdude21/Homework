/* Write a program that reads from the console a sequence of positive integer numbers. 
 * The sequence ends when empty line is entered. Calculate and print the sum and average 
 * of the elements of the sequence. Keep the sequence in List<int>. */
namespace SequenceOfPositiveIntegers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class SequenceOfPositiveIntegers
    {
        private static void Main()
        {
            var numbers = ReadInput();
            var sum = numbers.Sum();
            var average = sum / numbers.Count;

            Console.WriteLine("The sum is {0} and the average is {1}.", sum, average);
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