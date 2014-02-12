// Write a program that finds all prime numbers in the range [1...10 000 000]. 
// Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

using System;
using System.Collections.Generic;

class SieveOfEratosthenes
{
    static void Main()
    {
        bool[] range = new bool[10000001];
        Console.WriteLine("Warning! The program will take a significant ammount of time to run");

        // I initialize a boolean array that we'll use to store the numbers that are composite
        // I'll use the index of the array as the number

        // Those two nested for cycles are used to determine the composite numbers
        // cycle starts at the square of prime number

        for (long prime = 2; prime < range.Length; prime++)
        {
            for (long i = prime; i < range.Length; i++)
            {
                if (prime * i < range.Length)
                {
                    range[prime * i] = true;
                }
                else if (prime * i > range.Length)
                {
                    i = range.Length - 1;
                }
            }
        }

        // I use this for cycle to print all of the prime numbers
        // Those are the ones left with a value - false
        Console.WriteLine("These are the prime numbers: ");

        for (int i = 2; i < range.Length; i++)
        {
            if (!range[i])
            {
                Console.Write("{0}, ", i);
            }
        }
    }
}