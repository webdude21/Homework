// Write a program to convert hexadecimal numbers to their decimal representation.
namespace ConvertHexToDec
{
    using System;
    using System.Globalization;

    internal class Program
    {
        private static void Main()
        {
            EasyWayToDec();
            HarderWayToDec();
        }

        private static void EasyWayToDec()
        {
            Console.Write("Enter number a hexadecimal number: ");
            var num = int.Parse(Console.ReadLine(), NumberStyles.HexNumber);
            Console.Write("This is the result (the hard way): {0} ", num);
        }

        private static void HarderWayToDec()
        {
            Console.Write("Please input a Hexadecimal number: ");
            var binary = Console.ReadLine().ToUpper();
            var chrArray = binary.ToCharArray();
            var result = 0;
            var position = 0;
            var currentNumber = 0;

            for (var i = chrArray.Length - 1; i >= 0; i--)
            {
                if (chrArray[i] >= 'A')
                {
                    currentNumber = chrArray[i] - 'A' + 10;
                }
                else
                {
                    currentNumber = chrArray[i] - '0';
                }

                result = result + (currentNumber * (int)Math.Pow(16, position));
                position++;
            }

            Console.Write("This is the result (the hard way): {0}", result);
            Console.WriteLine();
        }
    }
}