namespace AnyToAnySystem
{
    using System;
    using System.Text;

    internal class AnyToAnySystem
    {
        private static void Main()
        {
            Console.Write("Please input S (the base of the input numeral system): ");
            var s = int.Parse(Console.ReadLine());
            Console.Write("Please input the number itself: ");
            var input = Console.ReadLine().ToUpper();
            Console.Write("Please input D (the base of the output numeral system): ");
            var d = int.Parse(Console.ReadLine());

            ConvertSToD(input, s, d);
        }

        private static void ConvertSToD(string input, int inputBase, int outputBase)
        {
            var chrArray = input.ToUpper().ToCharArray();
            var output = new StringBuilder();
            var currentInputDigit = 0;
            var position = 0;
            var numberDec = 0; // this is the number converted to decimal

            for (var i = chrArray.Length - 1; i >= 0; i--)
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

        private static char OutputCurrentDigit(int outputBase, ref int numberDec)
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

        private static int GetDigitFromChar(char currentChar, int currentDigit)
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

        private static void PrintResult(StringBuilder output)
        {
            // This is only to print the final result 
            Console.Write("This is the result: ");
            for (var i = output.Length - 1; i >= 0; i--)
            {
                Console.Write(output[i]);
            }

            Console.WriteLine();
        }
    }
}