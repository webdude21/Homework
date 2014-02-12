// Write a program to convert decimal numbers to their hexadecimal representation.

using System;

class ConvertDecimalToHex
{
    static void Main()
    {
        EasyWay();
        BitMoreDifficult();
    }
    static void EasyWay()
    {
        // This an built in function in C#, but I've decided it's too easy :)
        int num = GetInput();
        Console.Write("This is the result (the easy way): ");
        Console.WriteLine(Convert.ToString(num, 16));
    }

    static int GetInput()
    {
        Console.Write("Enter number: ");
        int num = int.Parse(Console.ReadLine());
        return num;
    }

    static void BitMoreDifficult()
    {
        int num = GetInput();
        string output = "";

        while (num != 0)
        {
            if (num % 16 > 9)
            {
                switch (num % 16)
                {
                    case 10: output = "A" + output;
                        break;
                    case 11: output = "B" + output;
                        break;
                    case 12: output = "C" + output;
                        break;
                    case 13: output = "D" + output;
                        break;
                    case 14: output = "E" + output;
                        break;
                    case 15: output = "F" + output; 
                        break;
                }
            }
            else
            {
                output = (num % 16) + output;
            }
            num /= 16;
        }

        Console.Write("This is the result (the hard way): {0} \r\n", output);
    }
}
