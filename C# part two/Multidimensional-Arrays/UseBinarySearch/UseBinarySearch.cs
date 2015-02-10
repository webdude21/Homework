// Write a program, that reads from the console an array of N integers and an integer K,
// sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 
namespace UseBinarySearch
{
    using System;
    using System.Collections.Generic;

    internal class UseBinarySearch
    {
        private static void Main()
        {
            GetUserInput();

            Test();
        }

        private static void GetUserInput()
        {
            Console.Write("Please input an integer for N: ");
            var n = int.Parse(Console.ReadLine());
            Console.Write("Please input an integer for K: ");
            var k = int.Parse(Console.ReadLine());

            var theArray = FillArrayWithInput(n);

            Array.Sort(theArray);

            var foundAt = Array.BinarySearch(theArray, k);

            PrintResult(foundAt, theArray);
        }

        private static void PrintResult(int foundAt, IList<int> list)
        {
            if (~foundAt >= list.Count && foundAt < 0)
            {
                Console.WriteLine("There's no number that fits the criteria.");
            }
            else if (foundAt < 0)
            {
                Console.WriteLine(
                    "The largest number that is next number smaller than K is {1} and it's at position {0}! ",
                    ~foundAt - 1,
                    list[~foundAt - 1]);
            }
            else
            {
                Console.WriteLine("K is at position {0}.", foundAt);
            }
        }

        private static int[] FillArrayWithInput(int n)
        {
            var theArray = new int[n];

            for (var i = 0; i < n; i++)
            {
                Console.Write("Please input an integer for element <{0}> of the array: ", i);
                var resultInput = int.TryParse(Console.ReadLine(), out theArray[i]);
                if (!resultInput)
                {
                    i--;
                }
            }

            return theArray;
        }

        private static void Test()
        {
            var k = 5;
            int[] testArray = { 0, 1, 3, 6, 3, 1, 6, 8, -3, 26 };

            Array.Sort(testArray);

            var foundAt = Array.BinarySearch(testArray, k);

            PrintResult(foundAt, testArray);
        }
    }
}