// Write a method that returns the index of the first element in array that is bigger than its neighbours, or -1, 
// if there’s no such element. Use the method from the previous exercise.

using System;

class FirstBiggerNeighbour
{
    static void Main()
    {
        int[] testArray = { 1, 2, 6, 8, 10, 15, 42, 2, 4, 2, 2, 8, 9 };
        Console.WriteLine("The first element that's bigger than its neighbours is: {0}", GetFirstLargerElement(testArray));
    }

    static int GetFirstLargerElement(int[] array)
    {
        foreach (int position in array)
        {
            if (CheckIfNeighboursAreSmaller(array, position))
            {
                return position;
            }
        }
        return -1;
    }

    static bool CheckIfNeighboursAreSmaller(int[] array, int number)
    {
        bool neighboursAreSmaller = false;

        if (number < 0 || number >= array.Length)
        {
            return neighboursAreSmaller;
        }
        else if (number == 0 || number == array.Length - 1)
        {
            return neighboursAreSmaller;
        }
        else
        {
            neighboursAreSmaller = (array[number] > array[number - 1] && array[number] > array[number + 1]);
        }

        return neighboursAreSmaller;
    }
}