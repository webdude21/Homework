// Write a program that reads from the console a string of maximum 20 characters. If the length of the string 
// is less than 20, the rest of the characters should be filled with '*'. Print the result string into the console.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class FillWithAsterisk
{
    static void Main()
    {
        try
        {
            string input = GetInput();
            Console.WriteLine("The result is: {0}", AddAsterisks(input));
       
        }
        catch (ArgumentOutOfRangeException me)
        {
            Console.WriteLine("The string was longer than 20 chars! {0}" , me.Message);   
        }

    }

    static string AddAsterisks(string input)
    {   // This method appends asterisks at the end of the string.
        StringBuilder newString = new StringBuilder();
        newString.Append(input);
        for (int i = input.Length; i < 20; i++)
        {
            newString.Append('*');
        }
        return newString.ToString();
    }

    static string GetInput()
    {   // This only gets the input and throws an exception if it can't.
        Console.Write("Please input a string (maximum 20 chars long: ");
        string input = Console.ReadLine();
        if (input.Length > 20)
        {
            throw (new ArgumentOutOfRangeException());
        }
        return input;
    }
}