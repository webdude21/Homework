// Write a program to convert binary numbers to hexadecimal numbers (directly).
namespace BinToHex
{
    using System;
    using System.Text;

    internal class BinToHex
    {
        private static void Main()
        {
            Console.Write("Enter number a binary number: ");
            GetBinToHex(Console.ReadLine());
        }

        private static void GetBinToHex(string input)
        {
            var chrArray = input.ToUpper().ToCharArray();
            var hex = new StringBuilder();
            var currentBinDigit = 0;
            var position = 0;
            var currentDigit = 0;

            for (var i = chrArray.Length - 1; i >= 0; i--)
            {
                currentBinDigit = GetBinDigitFromChar(chrArray[i], currentBinDigit);
                currentDigit = currentDigit + (currentBinDigit << position);
                position++;

                // If we have a complate set of four binary digits or we've reached the end fo the binary number
                // we convert the currentDigit to its HEX representation and append it to the string
                if (position == 4 || i == 0)
                {
                    if (currentDigit > 9)
                    {
                        hex.Append((char)(currentDigit + 'A' - 10));

                        // This converts the numbers from 10 to 15 A,B,C,D,E or F
                    }
                    else
                    {
                        hex.Append(currentDigit);
                    }

                    currentBinDigit = 0;
                    currentDigit = 0;
                    position = 0;
                }
            }

            PrintResult(hex);
        }

        private static int GetBinDigitFromChar(char currentChar, int currentBinDigit)
        {
            // This converts the a given char to a binary digit
            switch (currentChar)
            {
                case '0':
                    currentBinDigit = 0;
                    break;
                case '1':
                    currentBinDigit = 1;
                    break;
                default:
                    Console.WriteLine("The input wasn't valid.");
                    break;
            }

            return currentBinDigit;
        }

        private static void PrintResult(StringBuilder bin)
        {
            // This is only to print the final result 
            Console.Write("This is the result (the hard way): ");
            for (var i = bin.Length - 1; i >= 0; i--)
            {
                Console.Write(bin[i]);
            }

            Console.WriteLine();
        }
    }
}