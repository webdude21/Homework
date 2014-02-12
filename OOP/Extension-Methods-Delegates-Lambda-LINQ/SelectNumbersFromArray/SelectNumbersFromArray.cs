// Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
// Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

using System;
using System.Linq;

class SelectNumbersFromArray
{
    static void Main()
    {
        // Generate test Array
        int[] testArr = new int[200];

        for (int index = 0; index < testArr.Length; index++)
        {
            testArr[index] = index;
        }

        Console.WriteLine("Using lambda expression: ");
        foreach (var number in Array.FindAll(testArr, number => (number % 21 == 0)))
        {
            Console.WriteLine("{0} can be divided to both 3 and 7.", number);
        }

        Console.WriteLine("Using LINQ query: ");
        var selectedNumbers = from number in testArr
                              where number % 21 == 0
                              select number;

        foreach (var number in selectedNumbers)
        {
            Console.WriteLine("{0} can be divided to both 3 and 7.", number);
        }
    }
}
