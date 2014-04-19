// Write a recursive program that simulates the execution of n nested loops from 1 to n. 

using System;
using System.Collections.Generic;

namespace NestedLoopsN
{
    class NestedLoopsN
    {
        static int recursiveCalls;
        static void Main()
        {
            Console.Write("n= ");
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];
            GenerateCombinations(0, arr);
            Console.WriteLine("Number of recursive calls: {0}", recursiveCalls);
        }

        static void GenerateCombinations(int index, IList<int> arr)
        {
            recursiveCalls++;
            if (index == arr.Count)
            {
                // We only print the array after we've reached the bootom of the current
                // recursive call. That means the array is full and we can print it.
                PrintCombination(arr);
            }
            else
            {
                for (var i = 0; i < arr.Count; i++)
                {
                    arr[index] = i + 1;
                    GenerateCombinations(index + 1, arr);
                }
            }
        }

        static void PrintCombination(IEnumerable<int> arr)
        {
            foreach (var number in arr)
            {
                Console.Write(number);
            }
            Console.WriteLine();
        }
    }
}