// Write a program that reads a number and prints it as a decimal number, hexadecimal number, 
// percentage and in scientific notation. Format the output aligned right in 15 symbols.
namespace PrintNumberInDifferentFormats
{
    using System;

    internal class PrintNumberInDifferentFormats
    {
        private static void Main()
        {
            Console.Write("Please input a number: ");
            var input = int.Parse(Console.ReadLine());
            Console.WriteLine("{0,15:D}", input);
            Console.WriteLine("{0,15:X}", input);
            Console.WriteLine("{0,15:P}", input);
            Console.WriteLine("{0,15:E}", input);
            Console.WriteLine();
        }
    }
}