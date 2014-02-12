// Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

using System;

class CheckForLeapYear
{
    static void Main()
    {
        Console.Write("Please input year: ");

        if (DateTime.IsLeapYear(int.Parse(Console.ReadLine())))
        {
            Console.WriteLine("It's a leap year!");
        }
        else
        {
            Console.WriteLine("It's not a leap year!");
        }
    }
}