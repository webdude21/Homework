using System;
using System.Threading;
using System.Globalization;

class GreatestOfFive
{
    static void Main()
    {
        // Write a program that finds the greatest of given 5 variables.
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        var numbers = new int[5];
        var greatestNumber = int.MinValue;
        Console.WriteLine("Please enter five numbers (on separate lines).");

        for (var i = 0; i < 5; i++)
        {
            // I've used a loop to gather the numbers and compare them
            numbers[i] = int.Parse(Console.ReadLine());
        }

        for (var i = 0; i < 5; i++)
        {
            // I've used this loop to go trough all of the comparisons needed 
            // to reach the conclusion on what the biggest number is.
            if (numbers[i] > greatestNumber)
            {
                greatestNumber = numbers[i];
            }
        }
        Console.WriteLine("The greatest number is: {0}", greatestNumber);
    }
}
