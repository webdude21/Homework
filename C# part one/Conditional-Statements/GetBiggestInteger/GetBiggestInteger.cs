using System;

class GetBiggestInteger
{
    static void Main()
    {
        // Write a program that finds the biggest of three 
        // integers using nested if statements.

        int firstNumber, secondNumber, thirdNumber = 0;

        Console.WriteLine("Please enter three numbers (on separate lines).");
        firstNumber = int.Parse(Console.ReadLine());
        secondNumber = int.Parse(Console.ReadLine());
        thirdNumber = int.Parse(Console.ReadLine());

        if (firstNumber < secondNumber)
        {
            firstNumber = secondNumber;
            if (firstNumber < thirdNumber)
            {
                firstNumber = thirdNumber;
            }
        }
        else
        {
            if (firstNumber < thirdNumber)
            {
                thirdNumber = firstNumber;
            }
        }
        Console.WriteLine("The biggest number is {0}", firstNumber);
    }
}
