// Write a method that reverses the digits of given decimal number. Example: 256 >> 652
namespace ReverseNumber
{
    using System;
    using System.Globalization;

    internal class ReverseNumber
    {
        private static void Main()
        {
            Console.Write("Please input an integer: ");
            var testNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("The number {0} is {1} when reversed.", testNumber, ReversedNumber(testNumber));
        }

        private static int ReversedNumber(int number)
        {
            // I convert the number to array of chars. Then I reverse the array.
            // Then I convert the array of chars back to a number and return it to the caller.
            var numberAsChars = number.ToString(CultureInfo.InvariantCulture).ToCharArray();
            Array.Reverse(numberAsChars);
            var reversedNumberAsString = new string(numberAsChars);
            return int.Parse(reversedNumberAsString);
        }
    }
}