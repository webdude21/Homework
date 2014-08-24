namespace AllOrderedKsubNelements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class AllPermutations
    {
        private static int recursiveCalls;

        private static void Main()
        {
            Console.Write("k= ");
            var k = int.Parse(Console.ReadLine());
            string[] set = { "hi", "a", "b" };
            var combiationArray = new string[k];
            GeneratePermutations(0, set, combiationArray);
            Console.WriteLine("Number of recursive calls: {0} ", recursiveCalls);
        }

        private static void GeneratePermutations(int index, IEnumerable<string> set, IList<string> combinationList)
        {
            if (index == combinationList.Count)
            {
                Console.Write("({0}), ", string.Join(" ", combinationList));
                recursiveCalls++;
            }
            else
            {
                var enumerable = set as IList<string> ?? set.ToList();
                foreach (var chr in enumerable)
                {
                    combinationList[index] = chr;
                    GeneratePermutations(index + 1, enumerable, combinationList);
                }
            }
        }
    }
}