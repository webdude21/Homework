// Write a program to convert binary numbers to their decimal representation.

using System;

class BinaryToDecimal
{
    static void Main()
    {
        Console.Write("Please input a binary number: ");
        string binary = Console.ReadLine();
        char[] chrArray = binary.ToCharArray();
        int result = 0;
        int position = 0;
        int currentNumber = 0;

        for (int i = chrArray.Length - 1; i >= 0; i--)
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
