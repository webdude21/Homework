// Write a program that reads two integer numbers N and K and an array of N elements from the console. 
// Find in the array those K elements that have maximal sum.


using System;

class MaxSequenceInArray
{
    static void Main()
    {
        Console.Write("Please enter an integer for N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Please enter an integer for K: ");
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Please enter the next number: ");
            array[i] = int.Parse(Console.ReadLine());
        }
            int currentSum = 0;
            int maxSum = int.MinValue;
            int currentIndex = 0;
            int maxSumIndex = 0;


            for (int i = 0; i < n - k; i++)
            {
                if (currentSum == 0)
                {
                    currentIndex = i;
                }
                for (int j = i; j < i + k; j++)
                {
                    currentSum = currentSum + array[j];
                }
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxSumIndex = currentIndex;
                }
                currentSum = 0;
            }
            Print(array, array.Length, 0);
            Console.Write(" -> ");
            Print(array, k, maxSumIndex);
            Console.WriteLine();
        }
        static void Print(int[] array, int maxSeq, int maxSeqIndex)
        {
            Console.Write("{");
            for (int i = maxSeqIndex; i < maxSeqIndex + maxSeq; i++)
            {
                Console.Write(array[i]);

                if (i == maxSeq + maxSeqIndex - 1)
                {
                    Console.Write("}");
                    break;
                }
                Console.Write(", ");
            }
        }
    
}