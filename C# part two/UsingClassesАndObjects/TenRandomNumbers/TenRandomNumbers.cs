// Write a program that generates and prints to the console 10 random values in the range [100, 200].

using System;

class TenRandomNumbers
{
    static void Main()
    {
        Random RandomGenerator = new Random();

        for (int i = 1; i < 11; i++)
        {
            Console.WriteLine("This is random number {0}: {1}", i, RandomGenerator.Next(100, 200));
        }
    }
}