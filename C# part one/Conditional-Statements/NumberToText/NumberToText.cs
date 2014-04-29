using System;

class Program
{
    // Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation.

    static void Main()
    {
        string[] dec = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        string[] special = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        string[] mainDigits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        int input;
        Console.WriteLine("Please enter a number in the range [0, 999]");

        var isValid = int.TryParse(Console.ReadLine(), out input);
        if (isValid && input >= 0 && input < 1000)
        {
            var digit = input % 10;
            var tens = (input / 10) % 10;
            var hundred = (input / 100) % 10;

            if (hundred != 0)
            {
                Console.Write("{0} hundred ", mainDigits[hundred]);
                if (tens != 0 && tens != 1 && input >= 20)
                {
                    Console.Write("and {0} ", dec[tens]);
                    if (digit != 0)
                    {
                        Console.Write("{0} ", mainDigits[digit]);
                    }
                }
                else if (tens == 1)
                {
                    Console.Write("and {0}", special[digit]);
                }
                else
                {
                    if (digit != 0)
                    {
                        Console.Write("and {0} ", mainDigits[digit]);
                    }
                }
            }
            else
            {
                if (tens != 0 && tens != 1 && input >= 20)
                {
                    Console.Write("{0} ", dec[tens]);
                    if (digit != 0)
                    {
                        Console.Write("{0} ", mainDigits[digit]);
                    }
                }
                else if (tens == 1)
                {
                    Console.Write("{0}", special[digit]);
                }
                else
                {
                    Console.Write("{0} ", mainDigits[digit]);
                }

            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("The input is invalid!");
        }
    }
}