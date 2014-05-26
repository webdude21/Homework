namespace Assertions
{
    using System;
    using System.Diagnostics;

    internal class Assertions
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null && arr.Length > 0, "Input array cannot be empty");
            for (var index = 0; index < arr.Length - 1; index++)
            {
                var minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            Debug.Assert(arr != null && arr.Length > 0, "Input array cannot be empty");
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) where T : IComparable<T>
        {
            Debug.Assert(arr != null && arr.Length > 0, "Input array cannot be empty");
            var minElementIndex = startIndex;
            for (var i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            var oldX = x;
            x = y;
            y = oldX;
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) where T : IComparable<T>
        {
            Debug.Assert(startIndex <= endIndex, "startIndex index is greater than endIndex");
            Debug.Assert(arr != null && arr.Length > 0, "Input array cannot be empty");
            while (startIndex <= endIndex)
            {
                var midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }

        private static void Main()
        {
            int[] arr = { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            SelectionSort(new int[0]); // Test sorting empty array
            SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(BinarySearch(arr, -1000));
            Console.WriteLine(BinarySearch(arr, 0));
            Console.WriteLine(BinarySearch(arr, 17));
            Console.WriteLine(BinarySearch(arr, 10));
            Console.WriteLine(BinarySearch(arr, 1000));
        }
    }
}