using System;
using System.Collections.Generic;

namespace AllPermutations
{
    class AllPermutations
    {
        static int recursiveCalls;
        static void Main()
        {
            Console.Write("n= ");
            var n = int.Parse(Console.ReadLine());
            var array = new int[n];
            GeneratePermutations(0, array); 
            Console.WriteLine("Number of recursive calls: {0} ", recursiveCalls);
        }

        static void GeneratePermutations(int index, IList<int> array)
        {

            if (index == array.Count)
            {
                PrintCombination(array);
                recursiveCalls++;
            }
            else
            {   
                for (var i = 0; i < array.Count; i++)
                {
                    array[index] = i + 1;
                    GeneratePermutations(index + 1, array);
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