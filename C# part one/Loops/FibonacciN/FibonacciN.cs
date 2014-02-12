using System;

class FibonacciN
{
    static void Main(string[] args)
    {
        //Write a program that reads a number N and calculates the sum of the first N members of the sequence of Fibonacci:
        // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, … Each member of the Fibonacci sequence 
        // (except the first two) is a sum of the previous two members.

        Console.Write("Please input a number for N: ");
        int userInputN = int.Parse(Console.ReadLine());

        decimal currentNumber = 0;
        decimal nMinusTwo = currentNumber;
        Console.WriteLine(currentNumber);
        decimal nMinusOne = currentNumber + 1;
        Console.WriteLine(currentNumber + 1);
        currentNumber = 1;

        for (int i = 1; i < userInputN; i++)
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
