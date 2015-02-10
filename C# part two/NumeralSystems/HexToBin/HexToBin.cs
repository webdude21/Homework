// Write a program to convert hexadecimal numbers to binary numbers (directly).
namespace HexToBin
{
    using System;
    using System.Globalization;
    using System.Text;

    internal class HexToBin
    {
        private static void Main()
        {
            HexToBinTheEasyWay();
            HeXToBinTheHardWay();
        }

        private static void HexToBinTheEasyWay()
        {
            Console.Write("Enter number a hexadecimal number: ");
            Console.WriteLine(
                "This is the result (the easy way): {0}", 
                Convert.ToString(int.Parse(Console.ReadLine(), NumberStyles.HexNumber), 2));
        }

        private static void HeXToBinTheHardWay()
        {
            Console.Write("Enter number a hexadecimal number: ");
            var chrArray = Console.ReadLine().ToUpper().ToCharArray(); // read input as char array
            var bin = new StringBuilder();
            var currentDigit = 0;

            for (var i = chrArray.Length - 1; i >= 0; i--)
            {
                if (chrArray[i] >= 'A')
                {
                    currentDigit = chrArray[i] - 'A' + 10;
                }
                else
                {
                    currentDigit = chrArray[i] - '0';
                }

                while (currentDigit != 0)
                {
                    bin.Append(currentDigit % 2);
                    currentDigit = currentDigit / 2;
                }
            }

            PrintResult(bin);
        }

        private static void PrintResult(StringBuilder bin)
        {
            Console.Write("This is the result (the hard way): ");
            for (var i = bin.Length - 1; i >= 0; i--)
            {
                Console.Write(bin[i]);
            }

            Console.WriteLine();
        }
    }
}