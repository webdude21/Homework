/* Write a program that counts in a given array of double values the number 
 * of occurrences of each value. Use Dictionary<TKey,TValue>.
 * Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
 * -2.5  2 times
 * 3  4 times
 * 4  3 times */
namespace CountOccurrences
{
    using System;
    using System.Collections.Generic;

    internal class CountOccurrences
    {
        private static void Main()
        {
            var input = new[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            var dict = new Dictionary<double, int>();

            foreach (var item in input)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict.Add(item, 1);
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine("{0} => {1} times", item.Key, item.Value);
            }
        }
    }
}