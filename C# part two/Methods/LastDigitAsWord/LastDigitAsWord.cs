// Write a method that returns the last digit of given integer as an English word. Examples: 512 > "two", 1024 > "four", 12309 > "nine".
namespace LastDigitAsWord
{
    using System;

    internal class LastDigitAsWord
    {
        private static void Main()
        {
            Console.Write("Please input an integer: ");
            var a = int.Parse(Console.ReadLine());
            Console.WriteLine("The last digit of {0} is {1}.", a, ConvertLastDigitToWord(a));
        }

        private static string ConvertLastDigitToWord(int input)
        {
            // Nothing really special here ;)
            var result = string.Empty;
            var lastDigit = input % 10;

            switch (lastDigit)
            {
                case 0:
                    result = "zero";
                    break;
                case 1:
                    result = "one";
                    break;
                case 2:
                    result = "two";
                    break;
                case 3:
                    result = "three";
                    break;
                case 4:
                    result = "four";
                    break;
                case 5:
                    result = "five";
                    break;
                case 6:
                    result = "six";
                    break;
                case 7:
                    result = "seven";
                    break;
                case 8:
                    result = "eight";
                    break;
                case 9:
                    result = "nine";
                    break;
            }

            return result;
        }
    }
}