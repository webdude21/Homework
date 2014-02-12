using System;

class NestedLoopsN
{
    static int recursiveCalls = 0;
    static void Main()
    {
        Console.Write("n= ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        GenerateCombinations(0, arr);
        Console.WriteLine("Number of recursive calls: {0}", recursiveCalls);
    }

    static void GenerateCombinations(int index, int[] arr)
    {
        recursiveCalls++;
        if (index == arr.Length)
	    {
            // We only print the array after we've reached the bootom of the current
            // recursive call. That means the array is full and we can print it.
            PrintCombination(arr);
		    return;
	    }
        else
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[index] = i + 1;
                GenerateCombinations(index + 1, arr);
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