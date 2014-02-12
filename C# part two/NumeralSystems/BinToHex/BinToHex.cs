// Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;
using System.Text;

class BinToHex
{
    static void Main()
    {
        Console.Write("Enter number a binary number: ");
        GetBinToHex(Console.ReadLine());
    }

    static void GetBinToHex(string input)
    {
        char[] chrArray = input.ToUpper().ToCharArray();
        StringBuilder hex = new StringBuilder();
        int currentBinDigit = 0;
        int position = 0;
        int currentDigit = 0;
       

        for (int i = chrArray.Length - 1; i >= 0; i--)
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

    static int GetBinDigitFromChar(char currentChar, int currentBinDigit)
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

    static void PrintResult(StringBuilder bin)
    {
        // This is only to print the final result 
        Console.Write("This is the result (the hard way): ");
        for (int i = bin.Length - 1; i >= 0; i--)
        {
            Console.Write(bin[i]);
        }
        Console.WriteLine();
    }

}