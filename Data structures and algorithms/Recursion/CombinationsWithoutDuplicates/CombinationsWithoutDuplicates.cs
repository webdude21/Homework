// Modify the previous program to skip duplicates:
// n=4, k=2 >> (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
namespace CombinationsWithoutDuplicates
{
    using System;
    using System.Collections.Generic;

    internal class CombinationsWithoutDuplicates
    {
        private static int recursiveCalls;

        private static void Main()
        {
            Console.Write("n= ");
            var n = int.Parse(Console.ReadLine());
            Console.Write("k= ");
            var k = int.Parse(Console.ReadLine());
            var arr = new int[k];
            GenerateCombinations(0, arr, n, 0);
            Console.WriteLine("Number of recursive calls: {0} ", recursiveCalls);
        }

        private static void GenerateCombinations(int index, IList<int> arr, int n, int remainingElements)
        {
            recursiveCalls++;
            if (index == arr.Count)
            {
                PrintCombination(arr);
                return;
            }

            for (var i = remainingElements; i < n; i++)
            {
                arr[index] = i + 1;
                GenerateCombinations(index + 1, arr, n, arr[index]);
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