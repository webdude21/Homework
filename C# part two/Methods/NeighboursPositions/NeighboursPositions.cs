// Write a method that checks if the element at given position in given array of integers
// is bigger than its two neighbors (when such exist).
namespace NeighboursPositions
{
    using System;

    internal class NeighboursPositions
    {
        private static void Main()
        {
            int[] testArray = { 1, 2, 6, 8, 10, 15, 42, 2, 4, 2, 2, 8, 9 };
            const int NumberAtPosition = 8;
            CheckIfNeighboursAreSmaller(testArray, NumberAtPosition);
        }

        private static void CheckIfNeighboursAreSmaller(int[] array, int number)
        {
            if (number < 0 || number >= array.Length)
            {
                Console.WriteLine("There's no such element");
            }
            else if (number == 0 || number == array.Length - 1)
            {
                Console.WriteLine("There's only one neighbor.");
            }
            else
            {
                var neighboursAreSmaller = array[number] > array[number - 1] && array[number] > array[number + 1];
                Console.WriteLine(
                    "The element at position '{0}' is larger than its neighbors: {1}",
                    number,
                    neighboursAreSmaller);
            }
        }
    }
}