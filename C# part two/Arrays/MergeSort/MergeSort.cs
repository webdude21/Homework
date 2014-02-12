using System;

class MergeSortAlgorithm
{
    static void Main()
    {
        int[] array = new int[] { 15, 2, 16, 8, 17, 9, 3, 2, 1, 10, 8, 5, 6, 9 };
        // Define an array to be sorted
        array = MergeSort(array); // Using the MergeSort method that can be seen further down I sort the array

        Console.WriteLine("This is the sorted array:");
        foreach (int element in array) // Print the result
        {
            Console.Write("{0} ", element);
        }

        Console.WriteLine();
    }

    static int[] MergeSort(int[] arr)
    {
        // I've used recurstion to 
        if (arr.Length == 1) // if the array (subarray) is with lenght 1 we reach the bottom of the recursion
            return arr; // And return the up the call chain

        int middle = arr.Length / 2; // we set the middle to be the current array's (or subarray) lenght
        int[] left = new int[middle]; // we create a new subarray that's called left and the lenght is half of the previous one

        // using this for cycle we copy each element (up to the middle of the current array (or subarray)

        for (int i = 0; i < middle; i++)
        {
            left[i] = arr[i];
        }

        // We do the same for the right part, but naturaly this time we use the range from the middle until the end of the array
        int[] right = new int[arr.Length - middle];

        for (int i = 0; i < arr.Length - middle; i++)
        {
            right[i] = arr[i + middle];
        }

        // Here we recursevly call the method MergeSort itself to split the current sub array until we have pieces of just one integer
        // that we can compare

        left = MergeSort(left);
        right = MergeSort(right);

        int leftptr = 0;
        int rightptr = 0;

        int[] sorted = new int[arr.Length];
        for (int k = 0; k < arr.Length; k++)
        {
            if (rightptr == right.Length || ((leftptr < left.Length) && (left[leftptr] <= right[rightptr])))
            {
                sorted[k] = left[leftptr];
                leftptr++;
            }
            else if (leftptr == left.Length || ((rightptr < right.Length) && (right[rightptr] <= left[leftptr])))
            {
                sorted[k] = right[rightptr];
                rightptr++;
            }
        }
        return sorted;
    }
}
