// Modify the previous program to skip duplicates:
// n=4, k=2 >> (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
namespace CombinationsWithDuplicates
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
                // We only print the array after we've reached the bottom of the current
                // recursive call. That means the array is full and we can print it.
                PrintCombination(arr);
            }
            else
            {
                for (var i = remainingElements; i < n; i++)
                {
                    arr[index] = i + 1;
                    GenerateCombinations(index + 1, arr, n, i);
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