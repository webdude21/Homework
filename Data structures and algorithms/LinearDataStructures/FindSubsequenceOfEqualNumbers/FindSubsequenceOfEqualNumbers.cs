/* Write a method that finds the longest subsequence of equal numbers in given List<int> and returns the result
 * as new List<int>. Write a program to test whether the method works correctly. */
namespace FindSubsequenceOfEqualNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    internal class FindSubsequenceOfEqualNumbers
    {
        private static void Main()
        {
            FindSequance();
        }

        private static void FindSequance()
        {
            var numbers = ReadInput();
            var mostFrequentNumber = numbers[0];
            var currentSequenceLenght = 1;
            var currentNumber = numbers[0];
            var bestSequenceLenght = 1;

            for (var index = 1; index < numbers.Count; index++)
            {
                if (numbers[index] == currentNumber)
                {
                    currentSequenceLenght++;
                }
                else
                {
                    if (currentSequenceLenght > bestSequenceLenght)
                    {
                        bestSequenceLenght = currentSequenceLenght;
                        mostFrequentNumber = currentNumber;
                    }

                    currentSequenceLenght = 1;
                    currentNumber = numbers[index];
                }
            }

            Console.WriteLine(ConvertResultToString(mostFrequentNumber, bestSequenceLenght));
        }

        private static string ConvertResultToString(int number, int repeatTimes)
        {
            var resultBuilder = new StringBuilder();

            for (var i = 0; i < repeatTimes; i++)
            {
                resultBuilder.Append(number);
                resultBuilder.Append(", ");
            }

            resultBuilder.Remove(resultBuilder.Length - 2, 2);
            return resultBuilder.ToString();
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