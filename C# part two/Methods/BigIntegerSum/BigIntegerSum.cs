// Write a method that adds two positive integer numbers represented as arrays of digits
// (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
// Each of the numbers that will be added could have up to 10 000 digits.

using System;
using System.Collections.Generic;

class BigIntegerSum
{
    static void Main()
    {
        int[] integerOne = { 1, 2, 9, 9, 9, 5, 2, 0, 0, 1, 2, 5, 4, 4, 5, 1, 4, 3, 2, 4, 0, 1, 2, 5, 4, 4, 5, 1, 4, 3, 2, 4 };
        int[] integerTwo =          { 9, 9, 4, 5, 1, 4, 0, 0, 1, 2, 5, 4, 4, 5, 1, 4, 3, 2, 4, 2, 0, 0, 5, 2, 1, 8, 8, 9, 9 };

        // I print the list in reverse since I've added the items from right to left.
        PrintResult(SumNumbers(integerOne, integerTwo));
    }

    private static void PrintResult(List<int> items)
    {
        Console.Write("The sum is: ");
        for (int i = items.Count - 1; i >= 0; i--)
        {
            Console.Write("{0}", items[i]);
        }
        Console.WriteLine();
    }

    static List<int> SumNumbers(int[] a, int[] b)
    {
        // The sum numbers is done as we do it on paper
        Array.Reverse(a);
        Array.Reverse(b);
        int memory = 0; // This will be used to carry over the surplus from each digit being added.
        int biggerArray;
        int smallerArray;
        List<int> sum = new List<int>();

        if (a.Length > b.Length)
        {
            biggerArray = a.Length;
            smallerArray = b.Length;
        }
        else
        {
            biggerArray = b.Length;
            smallerArray = a.Length;
        }
        // This determines the length of the bigger array

        for (int digit = 0; digit < biggerArray; digit++)
        {
            if (digit < smallerArray) // Sum the common digits of both arrays.
            {
                if (a[digit] + b[digit] + memory < 10)
                {
                    sum.Add(a[digit] + b[digit] + memory);
                    memory = 0;
                }
                else
                {
                    sum.Add(a[digit] + b[digit] + memory - 10);
                    memory = 1;
                }
            }
            else if (a.Length > b.Length)
            {
                sum.Add(a[digit] + memory);
                memory = 0;
            }
            else if (a.Length < b.Length)
            {
                sum.Add(b[digit] + memory);
                memory = 0;
            }
        }
        return sum;
    }
}