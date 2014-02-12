// Write a method that checks if the element at given position in given array of integers
// is bigger than its two neighbours (when such exist).

using System;

class NeighboursPositions
{
    static void Main()
    {
        int[] testArray = { 1, 2, 6, 8, 10, 15, 42, 2, 4, 2, 2, 8, 9 };
        int numberAtPosition = 8;
        CheckIfNeighboursAreSmaller(testArray, numberAtPosition);
    }

    static void CheckIfNeighboursAreSmaller(int[] array, int number)
    {
        bool neighboursAreSmaller = false;

        if (number < 0 || number >= array.Length)
        {
            Console.WriteLine("There's no such element");
        }
        else if (number == 0 || number == array.Length - 1)
        {
            Console.WriteLine("There's only one neighbour.");
        }
        else
        {
            neighboursAreSmaller = (array[number] > array[number - 1] && array[number] > array[number + 1]);
            Console.WriteLine("The element at position '{0}' is larger than its neighbours: {1}", number, neighboursAreSmaller);
        }
    }
}