// You are given a sequence of positive integer values written into a string, separated by spaces. 
// Write a function that reads these values from given string and calculates their sum. Example:
// string = "43 68 9 23 318" >> result = 461

using System;
using System.Text;

class SumFromString
{
    static void Main()
    {
        GetUserInput();
       // Test String 
       // Console.WriteLine("The sum is: {0}", CalculateSumFromString("43 68 9 23 318"));
    }

    static void GetUserInput()
    {
        Console.Write("Please input a string of integers with space between them: ");
        Console.WriteLine("The sum is: {0}", CalculateSumFromString(Console.ReadLine()));
    }

    static int CalculateSumFromString(string input)
    {
        // create an array of strings that is broken down from the initial string using
        // the the space as delimiter
        string[] stringArray = input.Split(' ');
        int sum = 0;

        foreach (string number in stringArray)
        {
            sum = sum + int.Parse(number);
        }

        return sum;
    }
}