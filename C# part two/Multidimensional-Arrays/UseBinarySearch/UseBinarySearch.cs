// Write a program, that reads from the console an array of N integers and an integer K,
// sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 


using System;

class UseBinarySearch
{
    static void Main()
    {
       GetUserInput();
       // Test();
    }

    static void GetUserInput()
    {
        Console.Write("Please input an integer for N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Please input an integer for K: ");
        int k = int.Parse(Console.ReadLine());
        int kFoundAt = -1;

        int[] theArray = FillArrayWithInput(n);

        Array.Sort(theArray);

        kFoundAt = (Array.BinarySearch(theArray, k));

        PrintResult(kFoundAt, theArray);
    }

    private static void PrintResult(int kFoundAt, int[] theArray)
    {
        if (~kFoundAt >= theArray.Length && kFoundAt < 0)
        {
            Console.WriteLine("There's no number that fits the criteria.");
        }
        else if (kFoundAt < 0)
        {
            Console.WriteLine("The largest number that is next number smaller than K is {1} and it's at position {0}! ", ~kFoundAt - 1, theArray[~kFoundAt - 1]);
        }
        else
        {
            Console.WriteLine("K is at position {0}.", kFoundAt);
        }
    }

    private static int[] FillArrayWithInput(int n)
    {
        int[] theArray = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Please input an integer for element <{0}> of the array: ", i);
            bool resultInput = int.TryParse(Console.ReadLine(), out theArray[i]);
            if (!resultInput)
            {
                i--;
            }
        }
        return theArray;
    }

    static void Test()
    {
        int k = 5;
        int kFoundAt = -1;
        int[] testArray = { 0, 1, 3, 6, 3, 1, 6, 8, -3, 26 };

        Array.Sort(testArray);

            kFoundAt = (Array.BinarySearch(testArray, k));

            PrintResult(kFoundAt, testArray);
    }
}
