// Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.
namespace CheckForLeapYear
{
    using System;

    internal class CheckForLeapYear
    {
        private static void Main()
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
}