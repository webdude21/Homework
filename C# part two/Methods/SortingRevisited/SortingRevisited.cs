// Write a method that return the maximal element in a portion of array of integers starting at given index. 
// Using it write another method that sorts an array in ascending / descending order.
namespace SortingRevisited
{
    using System;
    using System.Collections.Generic;

    internal class SortingRevisited
    {
        private static void Main()
        {
            int[] testArray =
                {
                    1, 2, 9, 9, 9, 5, 2, 0, 0, 1, 2, 5, 4, 4, 5, 1, 4, 3, 2, 4, 0, 1, 7, 5, 4, 4, 5, 1, 4, 3, 
                    2, 4
                };
            Console.WriteLine("This is the initial array:");
            PrintArray(testArray);
            Console.WriteLine("This is the sorted array (Descending):");
            PrintArray(SortArrayDescending(testArray));
            Console.WriteLine("This is the sorted array (Ascending):");
            PrintArray(SortArrayAscending(testArray));
        }

        private static int GetMaximalElement(IList<int> array, int startIndex)
        {
            // The only thing this does is to return the position of the 
            // largest element in range selected
            var maxNumberIndex = startIndex;
            for (var i = startIndex; i < array.Count; i++)
            {
                if (array[i] > array[maxNumberIndex])
                {
                    maxNumberIndex = i;
                }
            }

            return maxNumberIndex;
        }

        private static int[] SortArrayDescending(int[] array)
        {
            // Selection sort algorithm
            for (var i = 0; i < array.Length; i++)
            {
                var maxIndex = GetMaximalElement(array, i);
                var temp = array[i];
                array[i] = array[maxIndex];
                array[maxIndex] = temp;
            }

            return array;
        }

        private static void PrintArray(int[] array)
        {
            foreach (var t in array)
            {
                Console.Write("{0} ", t);
            }

            Console.WriteLine();
        }

        private static int[] SortArrayAscending(int[] array)
        {
            // Here I reverse the array after it has been sorted in a descending way.
            Array.Reverse(SortArrayDescending(array));

            return array;
        }
    }
}