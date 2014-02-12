using System;

class CheckIfBitPositionIs1
{
static void Main(string[] args)
{
    // Write a boolean expression that returns if the bit at position p 
    // (counting from 0) in a given integer number v has value of 1. 
    // Example: v=5; p=1  false.

    Console.Write("Please input a value for 'v': ");
    int v = Convert.ToInt32(Console.ReadLine());
    Console.Write("Please input a value for 'p': ");
    int p = Convert.ToInt32(Console.ReadLine());
    int k = (1 << p);

    Console.WriteLine("Does bit {0} in the number {1} equal 1? >> {2}", p, v, ((v & k) == k));
    Console.WriteLine("Press any key to close the application!");
    Console.ReadLine();
}
}

