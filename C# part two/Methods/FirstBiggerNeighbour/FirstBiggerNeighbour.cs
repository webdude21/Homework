// Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, 
// if there’s no such element. Use the method from the previous exercise.
namespace FirstBiggerNeighbour
{
    using System;
    using System.Collections.Generic;

    internal class FirstBiggerNeighbour
    {
        private static void Main()
        {
            int[] testArray = { 1, 2, 6, 8, 10, 15, 42, 2, 4, 2, 2, 8, 9 };
            Console.WriteLine(
                "The first element that's bigger than its neighbors' is: {0}", 
                GetFirstLargerElement(testArray));
        }

        private static int GetFirstLargerElement(int[] array)
        {
            foreach (var position in array)
            {
                if (CheckIfNeighboursAreSmaller(array, position))
                {
                    return position;
                }
            }

            return -1;
        }

        private static bool CheckIfNeighboursAreSmaller(IList<int> array, int number)
        {
            if (number < 0 || number >= array.Count)
            {
                return false;
            }

            if (number == 0 || number == array.Count - 1)
            {
                return false;
            }

            var neighboursAreSmaller = array[number] > array[number - 1] && array[number] > array[number + 1];

            return neighboursAreSmaller;
        }
    }
}