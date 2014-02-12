// Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;
using System.Text;

class HexToBin
{
    static void Main()
    {
        HexToBinTheEasyWay();
        HeXToBinTheHardWay();
    }

    static void HexToBinTheEasyWay()
    {
        Console.Write("Enter number a hexadecimal number: ");
        Console.WriteLine("This is the result (the easy way): {0}", Convert.ToString(int.Parse(Console.ReadLine(), System.Globalization.NumberStyles.HexNumber), 2));
    }

    static void HeXToBinTheHardWay()
    {
        Console.Write("Enter number a hexadecimal number: ");
        char[] chrArray = Console.ReadLine().ToUpper().ToCharArray(); // read input as char array
        StringBuilder bin = new StringBuilder();
        int currentDigit = 0;

        for (int i = chrArray.Length -1; i >= 0; i--)
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

    static void PrintResult(StringBuilder bin)
    {
        Console.Write("This is the result (the hard way): ");
        for (int i = bin.Length - 1; i >= 0; i--)
        {
            Console.Write(bin[i]);
        }
        Console.WriteLine();
    }
}