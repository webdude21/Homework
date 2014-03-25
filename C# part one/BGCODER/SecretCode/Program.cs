using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        BigInteger a = BigInteger.Parse(Console.ReadLine());
        BigInteger b = BigInteger.Parse(Console.ReadLine());
        BigInteger c = BigInteger.Parse(Console.ReadLine());
        BigInteger result = 0;
        BigInteger output = 0;

        if (b == 2)
        {
            result = a % c;
        }
        else if (b == 4)
        {
            result = a + c;
        }
        else if (b == 8)
        {
            result = a * c;
        }
        if (result % 4 == 0)
        {
            output = result / 4;
        }
        else
        {
            output = result % 4;
        }

        Console.WriteLine(output);
        Console.WriteLine(result);
    }
}