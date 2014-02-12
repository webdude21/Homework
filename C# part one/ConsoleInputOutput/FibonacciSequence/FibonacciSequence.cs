using System;

class FibonacciSequence
{
    static void Main(string[] args)
    {

        decimal currentNumber = 0;

        decimal nMinusTwo = currentNumber;
        Console.WriteLine(currentNumber);
        decimal nMinusOne = currentNumber + 1;
        Console.WriteLine(currentNumber + 1);
        currentNumber = 1;

        for (byte i = 0; i < 99; i++)
        {
            Console.WriteLine(currentNumber);
            nMinusTwo = nMinusOne;
            nMinusOne = currentNumber;
            currentNumber = nMinusOne + nMinusTwo;
        }

        // Initially I used UInt64, but I found it wasn't enough to fit the last 10 or so numbers.
        // Then switched to 'decimal' data type. I used this page to check if everything is correct:
        // http://www.maths.surrey.ac.uk/hosted-sites/R.Knott/Fibonacci/fibtable.html

    }
}