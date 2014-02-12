using System;
using System.Text;

class AnyToAnySystem
{
    static void Main()
    {
        Console.Write("Please input S (the base of the input numeral system): ");
        int s = int.Parse(Console.ReadLine());
        Console.Write("Please input the number itself: ");
        string input = Console.ReadLine().ToUpper();
        Console.Write("Please input D (the base of the output numeral system): ");
        int d = int.Parse(Console.ReadLine());

        ConvertSToD(input, s, d);
    }

    static void ConvertSToD(string input, int inputBase, int outputBase)
    {
        char[] chrArray = input.ToUpper().ToCharArray();
        StringBuilder output = new StringBuilder();
        int currentInputDigit = 0;
        int position = 0;
        int numberDec = 0; // this is the number converted to decimal

        for (int i = chrArray.Length - 1; i >= 0; i--)
        {
            currentInputDigit = GetDigitFromChar(chrArray[i], currentInputDigit);
            numberDec = numberDec + (currentInputDigit * (int)Math.Pow(inputBase, position));
            position++;
        }

        while (numberDec != 0)
        {
            output.Append(OutputCurrentDigit(outputBase, ref numberDec));
        }
   
        PrintResult(output);
    }

    static char OutputCurrentDigit(int outputBase, ref int numberDec)
    { 
        // This method converts the decimal number to the output base "digit" 
        // "Digit" means char (in numeral systems larger then the Decimal one)
        char outputChar;

        if (numberDec % outputBase > 9)
        {
            outputChar = (char)((numberDec % outputBase) + 'A' - 10);
            numberDec = numberDec / outputBase;
        }
        else
        {
            outputChar = (char)((numberDec % outputBase) + '0');
            numberDec = numberDec / outputBase;
        }
        return outputChar;
    }

    static int GetDigitFromChar(char currentChar, int currentDigit)
    {
        // This converts a given char to a number
        if (currentChar >= 'A')
        {
            currentDigit = currentChar - 'A' + 10;
        }
        else
        {
            currentDigit = currentChar - '0';
        }
        return currentDigit;
    }

    static void PrintResult(StringBuilder output)
    {
        // This is only to print the final result 
        Console.Write("This is the result: ");
        for (int i = output.Length - 1; i >= 0; i--)
        {
            Console.Write(output[i]);
        }
        Console.WriteLine();
    }
}