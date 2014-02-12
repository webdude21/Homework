// Modify the previous program to skip duplicates:
// n=4, k=2 >> (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)

using System;

class CombinationsWithoutDuplicates
{
    static int recursiveCalls = 0;
    static void Main()
    {
        Console.Write("n= ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("k= ");
        int k = int.Parse(Console.ReadLine());
        int[] arr = new int[k];
        GenerateCombinations(0, arr, n, 0);
        Console.WriteLine("Number of recursive calls: {0} ", recursiveCalls);
    }

    static void GenerateCombinations(int index, int[] arr, int n, int remainingElements)
    {
        recursiveCalls++;
        if (index == arr.Length)
        {
            PrintCombination(arr);
            return;
        }
        else
        {
            for (int i = remainingElements; i < n; i++)
            {
                arr[index] = i + 1;
                GenerateCombinations(index + 1, arr, n, arr[index]);
            }
        }
    }

    static void PrintCombination(int[] arr)
    {
        foreach (int number in arr)
        {
            Console.Write(number);
        }
        Console.WriteLine();
    }
}