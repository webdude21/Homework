/* Write a program that reads a sequence of integers (List<int>) ending with
 * an empty line and sorts them in an increasing order. */
namespace SortNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class SortNumbers
    {
        private static void Main()
        {
            var numbers = ReadInput();
            numbers.Sort();
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
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