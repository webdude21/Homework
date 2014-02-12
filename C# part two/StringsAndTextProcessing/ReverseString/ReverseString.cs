// Write a program that reads a string, reverses it and prints the result at the console.
// Example: "sample" >> "elpmas".

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReversedString
{
    static void Main()
    {
        Console.Write("Please input a string: ");
        string str = Console.ReadLine();
        Console.WriteLine("The string {0} is {1} when reversed.", str, ReverseString(str));
    }

    static string ReverseString(string str)
    {
        char[] stringAsChars = str.ToCharArray();
        Array.Reverse(stringAsChars);
        return new string(stringAsChars);
    }
}