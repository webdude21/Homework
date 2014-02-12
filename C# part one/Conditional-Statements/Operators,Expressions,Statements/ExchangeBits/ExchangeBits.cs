using System;

class Program
{
    static void Main(string[] args)
    {
        // Write a program that exchanges bits 3, 4 and 5 with bits
        // 24, 25 and 26 of given 32-bit unsigned integer.

        Console.Write("Please input a value for the integer: ");
        uint n = Convert.ToUInt32(Console.ReadLine());
        uint bit345mask = n >> 3 << 29 >> 5;
        uint bit242526mask = n >> 24 << 29 >> 26;
        n = (n & ~56u & ~117440512u ^ bit345mask ^ bit242526mask); 
        Console.WriteLine("After the operation the value of the integer is {0}!", n);
        Console.WriteLine("Press any key to close the application!");
        Console.ReadLine();

        // I have a feeling that I've made it much more complicated then nescecary!
    }
}

