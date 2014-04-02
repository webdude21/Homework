// Write a program to calculate n! for each n in the range [1..100]. Hint: Implement first a
// method that multiplies a number represented as array of digits by given integer number. 

using System;
using System.Collections.Generic;

class CalcFact
{
    static void Main()
    {
        Fact(GetInput());
    }

    private static int GetInput()
    {
        // This method gets the input from the user and validates it
        // I've left to accept more the n>100 because the program handles it well up to 10000
        Console.Write("Please input n for the !n calculation: ");
        int n;
        var validInput = int.TryParse(Console.ReadLine(), out n);

        while (!validInput)
        {
            Console.WriteLine("The input was invalid.");
            Console.Write("Please input n for the !n calculation: ");
            validInput = int.TryParse(Console.ReadLine(), out n);
        }

        if (n > 10000)
        {   // A warning to the user if they entered an insane number
            // I've tried it and eventualy it gets calculated and printed
            Console.WriteLine("This may take a long time ...");
        }

        return n;
    }

    static List<int> MultiplyNumber(IReadOnlyList<int> a, int b)
    {
        var memory = 0; 
        // This will be used to carry over the surplus from each digit being added.
        var result = new List<int>(); // This list will hold the digits
        for (var i = a.Count - 1; i >= 0; i--)
        {
            if (((a[i] * b) + memory) < 10)
            {
                // Add the memory to the digit and then discard it.
                result.Add((a[i] * b) + memory);
                memory = 0;
            }
            else
            {
                // Get the last digit of the following
                result.Add(((a[i] * b) + memory) % 10);
                // The rest put in the memory
                memory = ((a[i] * b) + memory) / 10;
            }
        }

        // after the for cycles has stopped if there's some memory left digits for it until it reaches 0
        while (memory != 0) 
        {
            if (memory > 9)
            {
                // if the number is larger than 9 (no longer a digit)
                // get only the last digit and remove it from the memory
                result.Add(memory % 10);
                memory = memory / 10;
            }
            else
            {
                // if it's a digit, just add it to the list of digits
                // set the memory to 0 and the while cycle stops.
                result.Add(memory);
                memory = 0;
            }
        }

        result.Reverse();
        return result;
    }

    static void PrintList(IEnumerable<int> input)
    {
        // Straight forword printing of the list of digits
        foreach (var element in input)
        {
            Console.Write("{0}", element);
        }
        Console.WriteLine();
    }

    static void Fact(int n)
    {
        // This calculates the factorial
        var resultFact = new List<int> {1};

        for (var currFact = 1; currFact <= n; currFact++)
        {
            resultFact = MultiplyNumber(resultFact, currFact);
        }
        PrintList(resultFact);
    }
}