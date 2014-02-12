// Write a method GetMax() with two parameters that returns the bigger of two integers. 
// Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

using System;

class GetMaxMethod
{
    static void Main()
    {
        Console.WriteLine("Please input 3 integers each on a new line!");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        
        // Here the method uses itself to narrow the search for the largest number
        Console.WriteLine("The biggest integer is {0}: ", GetMax(GetMax(a, b), GetMax(b, c)));
    }

    static int GetMax(int a, int b)
    {
        return (a < b) ? a = b : a;
    }
}