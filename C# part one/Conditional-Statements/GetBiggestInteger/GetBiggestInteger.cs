using System;

class GetBiggestInteger
{
    static void Main()
    {
        // Write a program that finds the biggest of three 
        // integers using nested if statements.

        Console.WriteLine("Please enter three numbers (on separate lines).");
        var firstNumber = int.Parse(Console.ReadLine());
        var secondNumber = int.Parse(Console.ReadLine());
        var thirdNumber = int.Parse(Console.ReadLine());

        if (firstNumber < secondNumber)
            firstNumber = secondNumber;
        if (firstNumber < thirdNumber)
            firstNumber = thirdNumber;

        Console.WriteLine("The biggest number is {0}", firstNumber);
    }
}
