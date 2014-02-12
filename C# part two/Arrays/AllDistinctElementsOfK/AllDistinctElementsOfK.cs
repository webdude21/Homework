//    Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. Example:
//    N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

using System;

class AllVariationsOfK
{
    static void Main()
    {
        int n;
        int k;
        Console.Write("Please input a valid input for N: ");
        bool resultN = int.TryParse(Console.ReadLine(), out n);
        Console.Write("Please input a valid input for K: ");
        bool resultk = int.TryParse(Console.ReadLine(), out k);

        if (!resultk && resultN)
        {
            Main();
        }

        int[] varInt = new int[k];
        GenCombinations(varInt, n, 0, 0);
    }

    static void GenCombinations(int[] arr, int n, int index, int iter)
    {
        if (arr.Length == index)
        {
            // Whenever we reach arr.Length a.k.a "K"
            // We've filled the array so we print the result
            Print(arr);
            return;
        }
        else
        {
            for (int q = iter; q < n; q++)
            {
                arr[index] = q + 1;
                GenCombinations(arr, n, index + 1, q + 1);
            }
        }   
    }

    static void Print(int[] arr)
    {   
        Console.Write("<");
        for (int i = 0; i < arr.Length; i++)
        {
            if(i == arr.Length - 1)
            {
                Console.Write(arr[i]);
            }
            else
            {
                Console.Write("{0}, ", arr[i]);
            }
        }
        Console.WriteLine(">");
    }
}