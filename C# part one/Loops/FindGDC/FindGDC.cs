using System;

class FindGDC
{
    static void Main()
    {
        // Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm (find it in Internet).

        Console.Write("Please input a two integers: ");
        int firstInteger = int.Parse(Console.ReadLine());
        int secondInteger = int.Parse(Console.ReadLine());

        while (firstInteger != 0 && secondInteger != 0)
        {
            if (firstInteger > secondInteger)
            {
                firstInteger -= secondInteger;
            }
            else
            {
                secondInteger -= firstInteger;
            }
        }
        Console.WriteLine("The greatest common divisor is {0}", Math.Max(firstInteger, secondInteger));
    }
}
