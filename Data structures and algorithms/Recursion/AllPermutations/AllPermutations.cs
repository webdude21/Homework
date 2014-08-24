/* Write a recursive program for generating and printing all permutations of the numbers 
 * 1, 2, ..., n for given integer number n. Example: 
 * n=3 => {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1} */
namespace AllPermutations
{
    using System;
    using System.Collections.Generic;

    internal class AllPermutations
    {
        private static int recursiveCalls;

        private static void Main()
        {
            Console.Write("n= ");
            var n = int.Parse(Console.ReadLine());
            var array = new int[n];
            var usedNumbers = new bool[n];
            GeneratePermutations(0, array, usedNumbers);
            Console.WriteLine("Number of recursive calls: {0} ", recursiveCalls);
        }

        private static void GeneratePermutations(int index, IList<int> array, IList<bool> usedNumbers)
        {
            if (index == array.Count)
            {
                PrintCombination(array);
                recursiveCalls++;
                return;
            }

            for (var i = 0; i < array.Count; i++)
            {
                if (!usedNumbers[i])
                {
                    array[index] = i + 1;
                    usedNumbers[i] = true;
                    GeneratePermutations(index + 1, array, usedNumbers);
                    usedNumbers[i] = false;
                }
            }
        }

        private static void PrintCombination(IEnumerable<int> arr)
        {
            foreach (var number in arr)
            {
                Console.Write(number);
            }

            Console.WriteLine();
        }
    }
}