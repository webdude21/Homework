using System;

class ReadPositiveIntegers
{
    static void Main(string[] args)
    {
        uint a;
        uint b;
        uint p; // p is first used as a buffer to flip the places of a and b if necessary.

        Console.Write("Please enter the first integer: ");
        a = uint.Parse(Console.ReadLine());
        Console.Write("Please enter the second integer: ");
        b = uint.Parse(Console.ReadLine());

        if (a > b)
        {
            p = b;
            b = a;
            a = p;
        }

        // Ensures that a is always the smaller number so the loop can operate as intended.

        p = 0; 

        for (uint k =(uint)a; k <= b; k++)
        {
            if (k % 5 == 0) {p++;}
        }
        Console.WriteLine("p({1},{2}) = {0}", p, a, b);
    }
}
