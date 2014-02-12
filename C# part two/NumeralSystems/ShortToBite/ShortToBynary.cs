using System;
using System.Text;


class ShortToBynary
{
    static void Main()
    {
        ShortToByteTheEaseyWay();
        ShortToByteTheOtherWay();
    }

    static void ShortToByteTheEaseyWay()
    {
        // This is again the trivial built in way
        Console.Write("Please enter a signed short integer: ");
        Console.Write("The binary representation of the number is: {0}", Convert.ToString(short.Parse(Console.ReadLine()), 2));
        Console.WriteLine();
    }

    static void ShortToByteTheOtherWay()
    {
        Console.Write("Please enter a signed short integer: ");
        short input = short.Parse(Console.ReadLine());
        string output = "";

        // Bit shifting way
        // The current string is concatenated to current bit and the current string 
        // (putting each and every digit on the left side of the already existring one)
        // Could have done it with string builder

        for (int i = 0; i < 16; i++)
        {
            output = ((input >> i) & 1) + output;
        }

        Console.Write("The binary representation of the number is: {0}", output);
        Console.WriteLine();
    }


}