// Write a program that reads two arrays from the console and compares them element by element.

using System;

class TwoArrayCompare
{
    static void Main()
    {
        Console.WriteLine("Enter the array length:");
        int n = int.Parse(Console.ReadLine());
        int[] firstArray = new int[n];
        int[] secondArray = new int[n];
        for (int i = 0; i < firstArray.Length; i++)
        {
            Console.WriteLine("Enter element - {0} from the first array", i + 1);
            firstArray[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < firstArray.Length; i++)
        {
            Console.WriteLine("Enter element - {0} from the second array", i + 1);
            secondArray[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(firstArray);
        Array.Sort(secondArray);
        for (int i = 0; i < firstArray.Length; i++)
        {
            if (firstArray[i] == secondArray[i])
            {
                Console.WriteLine("Element {0} is equal in both arrays.", i + 1);
            }
            else
            {
                Console.WriteLine("Element {0} is different in both arrays", i + 1);
            }
        }

    }
}