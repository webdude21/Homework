/* Write a program that finds in given array of integers (all belonging 
 * to the range [0..1000]) how many times each of them occurs.
 * Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2} */

namespace NumberOccurenceFrequency
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NumberOccurenceFrequency
    {
        static void Main()
        {
            var numberSequence = new List<int> { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            foreach (var number in numberSequence.GroupBy(number => number)
                .ToDictionary(group => group.Key, group => group.Count()))
            {
                Console.WriteLine("{0} -> {1} times", number.Key, number.Value);
            }
        }
    }
}
