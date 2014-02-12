using System;

class DigitToName
{
    static void Main()
    {
        // Write program that asks for a digit and depending on the input shows
        // the name of that digit (in English) using a switch statement.

        int digit;

        Console.WriteLine("Please enter three a single digit.");
        digit = int.Parse(Console.ReadLine());
        switch (digit)
        {
            case 1: Console.WriteLine("The digit is one");
                break;
            case 2: Console.WriteLine("The digit is two");
                break;
            case 3: Console.WriteLine("The digit is three");
                break;
            case 4: Console.WriteLine("The digit is four");
                break;
            case 5: Console.WriteLine("The digit is five");
                break;
            case 6: Console.WriteLine("The digit is six");
                break;
            case 7: Console.WriteLine("The digit is seven");
                break;
            case 8: Console.WriteLine("The digit is eight");
                break;
            case 9: Console.WriteLine("The digit is nine");
                break;
            case 0: Console.WriteLine("The digit is zero");
                break;
            default: Console.WriteLine("You've entered something else!");
                break;
        }
    }
}
