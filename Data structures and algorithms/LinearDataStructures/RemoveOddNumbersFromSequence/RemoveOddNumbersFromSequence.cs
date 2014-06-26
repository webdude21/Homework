/* Write a program that removes from given sequence all numbers 
 * that occur odd number of times. Example:
   {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5} */
namespace RemoveOddNumbersFromSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class RemoveOddNumbersFromSequence
    {
        private static void Main()
        {
            var numberSequence = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            var countDictionary = numberSequence.GroupBy(number => number)
                .ToDictionary(group => group.Key, group => group.Count());
            Console.WriteLine(string.Join(", ", numberSequence.Where(number => countDictionary[number] % 2 == 0)));
        }
    }
}