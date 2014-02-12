// Write a method that reverses the digits of given decimal number. Example: 256 >> 652

using System;

class ReverseNumber
{
    static void Main()
    {
        Console.Write("Please input an integer: ");
        int testNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("The number {0} is {1} when reversed.", testNumber, ReversedNumber(testNumber));
    }

    static int ReversedNumber(int number)
    {
        // I convert the number to array of chars. Then I reverse the array.
        // Then I convert the array of chars back to a number and return it to the caller.
        char[] numberAsChars = number.ToString().ToCharArray();
        Array.Reverse(numberAsChars);
        string reversedNumberAsString = new string(numberAsChars);
        return int.Parse(reversedNumberAsString);
    }
}