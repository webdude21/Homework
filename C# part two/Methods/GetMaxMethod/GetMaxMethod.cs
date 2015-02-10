// Write a method GetMax() with two parameters that returns the bigger of two integers. 
// Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().
namespace GetMaxMethod
{
    using System;

    internal class GetMaxMethod
    {
        private static void Main()
        {
            Console.WriteLine("Please input 3 integers each on a new line!");
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());

            // Here the method uses itself to narrow the search for the largest number
            Console.WriteLine("The biggest integer is {0}: ", GetMax(GetMax(a, b), GetMax(b, c)));
        }

        private static int GetMax(int a, int b)
        {
            return (a < b) ? b : a;
        }
    }
}