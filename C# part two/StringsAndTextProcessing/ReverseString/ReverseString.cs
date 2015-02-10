// Write a program that reads a string, reverses it and prints the result at the console.
// Example: "sample" >> "elpmas".
namespace ReverseString
{
    using System;

    internal class ReversedString
    {
        private static void Main()
        {
            Console.Write("Please input a string: ");
            var str = Console.ReadLine();
            Console.WriteLine("The string {0} is {1} when reversed.", str, ReverseString(str));
        }

        private static string ReverseString(string str)
        {
            var stringAsChars = str.ToCharArray();
            Array.Reverse(stringAsChars);
            return new string(stringAsChars);
        }
    }
}