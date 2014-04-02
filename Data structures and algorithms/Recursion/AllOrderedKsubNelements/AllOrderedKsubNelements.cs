using System;
using System.Collections.Generic;

namespace AllPermutations
{
    class AllPermutations
    {
        static int recursiveCalls;
        static void Main()
        {
            Console.Write("k= ");
            var k = int.Parse(Console.ReadLine());
            string[] set = {"hi", "a", "b"};
            var combiationArray = new string[k];
            GeneratePermutations(0, set, combiationArray);
            Console.WriteLine("Number of recursive calls: {0} ", recursiveCalls);
        }

        static void GeneratePermutations(int index, IEnumerable<string> set, IList<string> combinationList)
        {
            if (index == combinationList.Count)
            {
                Console.Write("({0}), ", string.Join(" ", combinationList));
                recursiveCalls++;
            }
            else
            {
                foreach (var chr in set)
                {
                    combinationList[index] = chr;
                    GeneratePermutations(index + 1, set, combinationList);
                }
            }
        }
    }
}