using System;

class QuickSortAlgo
{
    static void Main()
    {
        int[] array = new int[] { 15, 2, 16, 8, 17, 9, 3, 2, 1, 10, 8, 5, 6, 9 };
        // Define an array to be sorted

        QuickSort(array);
        Console.WriteLine("This is the sorted array:");
        foreach (int element in array) // Print the result
        {
            Console.Write("{0} ", element);
        }
        Console.WriteLine();
    }
    static void QuickSort(int[] array)
    {
        QuickSortAdvanced(array, 0, array.Length - 1);
    }

    static void QuickSortAdvanced(int[] array, int leftSide, int rightSide)
    {
        int leftTemp = leftSide;
        int rightTemp = rightSide;
        int pivot = array[leftSide];
        while (leftSide < rightSide)
        {
            while ((array[rightSide] >= pivot) && (leftSide < rightSide))
            {
                rightSide--;
            }
            if (leftSide != rightSide)
            {
                array[leftSide] = array[rightSide];
                leftSide++;
            }
            while ((array[leftSide] <= pivot) && (leftSide < rightSide))
            {
                leftSide++;
            }
            if (leftSide != rightSide)
            {
                array[rightSide] = array[leftSide];
                rightSide--;
            }
        }
        array[leftSide] = pivot;
        pivot = leftSide;
        leftSide = leftTemp;
        rightSide = rightTemp;
        if (leftSide < pivot)
            QuickSortAdvanced(array, leftSide, pivot - 1);
        if (rightSide > pivot)
            QuickSortAdvanced(array, pivot + 1, rightSide);
    }
}