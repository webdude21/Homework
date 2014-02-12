// Write a program to convert hexadecimal numbers to their decimal representation.

using System;

class Program
{
    static void Main()
    {
        EasyWayToDec();
        HarderWayToDec();
    }

    static void EasyWayToDec()
    {
        Console.Write("Enter number a hexadecimal number: ");
        int num = int.Parse(Console.ReadLine(), System.Globalization.NumberStyles.HexNumber);
        Console.Write("This is the result (the hard way): {0} ", num);
    }

    static void HarderWayToDec()
    {
        Console.Write("Please input a Hexadecimal number: ");
        string binary = Console.ReadLine().ToUpper();
        char[] chrArray = binary.ToCharArray();
        int result = 0;
        int position = 0;
        int currentNumber = 0;

        for (int i = chrArray.Length - 1; i >= 0; i--)
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