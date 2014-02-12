using System;
using System.Threading;
using System.Globalization;


class GreatestOfFive
{
    static void Main()
    {
        // Write a program that finds the greatest of given 5 variables.
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;  

        double[] numbers = new double[5];
        double? greatestNumber = null;
		Console.WriteLine("Please enter five numbers (on separate lines).");
		
		for (int i = 0; i < 5; i++)
        {
		// I've used a loop to gather the numbers and compare them
            numbers[i] = double.Parse(Console.ReadLine());
        }

        for (int i = 0; i < 4; i++)
        {
		// I've used this loop to go trough all of the comparisons needed 
		// to reach the conclusion on what the biggest number is.
			if (numbers[i] > numbers[i+1])
			{
			greatestNumber = numbers[i];
			}
		greatestNumber = numbers[i+1];
        }

        Console.WriteLine("The greatest number is: {0}", greatestNumber);
    }
}
