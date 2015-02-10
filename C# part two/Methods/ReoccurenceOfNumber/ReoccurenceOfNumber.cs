// Write a method that counts how many times given number appears in given array.
// Write a test program to check if the method is working correctly.
namespace ReoccurenceOfNumber
{
    using System;

    internal class ReoccurenceOfNumber
    {
        private static void Main()
        {
            int[] testArray = { 1, 2, 6, 8, 10, 15, 42, 2, 4, 2, 2, 8, 9 };
            var numberToLookFor = 2;
            Console.WriteLine(
                "The number '{0}' repeats {1} times in the array.", 
                numberToLookFor, 
                CountReoccurenceInArray(testArray, numberToLookFor));
        }

        private static int CountReoccurenceInArray(int[] array, int number)
        {
            var reoccurence = 0;

            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    reoccurence++;
                }
            }

            return reoccurence;
        }
    }
}