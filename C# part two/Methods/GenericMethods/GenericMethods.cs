// * Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.).
// Use generic method (read in Internet about generic methods in C#).

using System;

class GenericMethods
{
    static void Main()
    {
        Demo();
    }

    private static void Demo()
    {
        byte a = 9;
        byte b = 10;
        byte c = 4;
        int k = -8;
        int i = 9;
        float j = 7.5F;

        Console.WriteLine(MinimumNumber(a, b, c, k, i, j));
        Console.WriteLine(MaximumNumber(a, b, c, k, i, j));
        Console.WriteLine(SumNumbers(a, b, c, k, i, j));
        Console.WriteLine(AverageNumbers(a, b, c, k, i, j));
        Console.WriteLine(MultiplyNumbers(a, b, c, k, i, j));
    }

    static anyNumber MinimumNumber<anyNumber>(params anyNumber[] input)
    {
        Array.Sort(input);
        return input[0];
    }

    static anyNumber MaximumNumber<anyNumber>(params anyNumber[] input)
    {
        Array.Sort(input);
        return input[input.Length - 1];
    }

    static anyNumber SumNumbers<anyNumber>(params anyNumber[] input)
    {
        dynamic sum = 0;
        for (int i = 0; i < input.Length; i++)
        {
            sum = sum + input[i];
        }

        return sum;
    }

    static anyNumber MultiplyNumbers<anyNumber>(params anyNumber[] input)
    {
        dynamic product = 1;
        for (int i = 0; i < input.Length; i++)
        {
            product = product * input[i];
        }

        return product;
    }

    static anyNumber AverageNumbers<anyNumber>(params anyNumber[] input)
    {
        return (dynamic)SumNumbers(input) / input.Length;
    }
}