// Write a program to convert binary numbers to their decimal representation.
namespace BinaryToDecimal
{
    using System;

    internal class BinaryToDecimal
    {
        private static void Main()
        {
            Console.Write("Please input a binary number: ");
            var binary = Console.ReadLine();
            var chrArray = binary.ToCharArray();
            var result = 0;
            var position = 0;
            var currentNumber = 0;

            for (var i = chrArray.Length - 1; i >= 0; i--)
            {
                switch (chrArray[i])
                {
                    case '0':
                        currentNumber = 0;
                        break;
                    case '1':
                        currentNumber = 1;
                        break;
                    default:
                        Console.WriteLine("The input wasn't valid.");
                        break;
                }

                result = result + (currentNumber << position);
                position++;
            }

            Console.WriteLine(result);
        }
    }
}