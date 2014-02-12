// Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.

using System;

class TestClass
{
    static void Main()
    {
        // The only purpose of this class and method is to test the extension methods
        double[] doubleArray = new double[10];

        for (int i = 0; i < doubleArray.Length; i++)
        {
            doubleArray[i] = i * 2.3 + 1.6;
        }

        Console.WriteLine("The min is: {0}", doubleArray.Min());
        Console.WriteLine("The max is: {0}", doubleArray.Max());
        Console.WriteLine("The sum is: {0}", doubleArray.Sum());
        Console.WriteLine("The product is: {0}", doubleArray.Product());
        Console.WriteLine("The average is: {0}", doubleArray.Average());
    }
}
