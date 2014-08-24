/* Write a program that extracts from a given sequence of strings all 
 * elements that present in it odd number of times. Example:
 * {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL} */
namespace ExtractWordsWithOddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ExtractWordsWithOddOccurrences
    {
        private static void Main()
        {
            var input = new[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            var dict = new Dictionary<string, int>();

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

            Console.WriteLine(string.Join(", ", dict.Where(x => x.Value % 2 != 0).Select(x => x.Key)));
        }
    }
}