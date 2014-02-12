using System;

class ExchangeBits2
{
    static void Main(string[] args)
    {
        // * Write a program that exchanges bits {p, p+1, …, p+k-1) with bits 
        // {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

        Console.Write("Please input a value for the integer: ");
        uint n = Convert.ToUInt32(Console.ReadLine()); 
        Console.Write("Please input the 'p' position in the integer: ");
        int p = Convert.ToInt32(Console.ReadLine()); 
        Console.Write("Please input the 'q' position in the integer: ");
        int q = Convert.ToInt32(Console.ReadLine()); 
        Console.Write("Please input 'k' as the number of bits to exchange: ");
        int k = Convert.ToInt32(Console.ReadLine()); 

        uint maskq = ((n << (31 - (p + (k - 1)))) >> (31 - (k-1))) << q;
        uint maskp = ((n << (31 - (q + (k - 1)))) >> (31 - (k-1))) << p;
        uint clearmaskp = (~0u << (31 - (k - 1))) >> (31 - q - (k - 1)); 
        uint clearmaskq = (~0u << (31 - (k - 1))) >> (31 - p - (k - 1)); 
        n = (n & ~clearmaskp) & ~clearmaskq;
        n = (n | maskp) | maskq;

        Console.WriteLine("The new number is {0}", n);
        Console.WriteLine("Press any key to close the application!");
        Console.ReadLine();
    }
}
