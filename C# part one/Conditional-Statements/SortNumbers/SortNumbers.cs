using System;

class SortNumbers
{
    static void Main()
    {
        // Sort 3 real values in descending order using 
        // nested if statements.

        decimal tempNumber;

        Console.WriteLine("Please enter three numbers (on separate lines).");
        var firstNumber = decimal.Parse(Console.ReadLine());
        var secondNumber = decimal.Parse(Console.ReadLine());
        var thirdNumber = decimal.Parse(Console.ReadLine());

        if (secondNumber < thirdNumber)
        {
            tempNumber = secondNumber;
            secondNumber = thirdNumber;
            thirdNumber = tempNumber;
            if (firstNumber < secondNumber)
            {
                tempNumber = firstNumber;
                firstNumber = secondNumber;
                secondNumber = tempNumber;
                if (secondNumber < thirdNumber)
                {
                    tempNumber = secondNumber;
                    secondNumber = thirdNumber;
                    thirdNumber = tempNumber;
                }
            }
        }
        if (firstNumber < secondNumber)
        {
            tempNumber = firstNumber;
            firstNumber = secondNumber;
            secondNumber = tempNumber;
            if (secondNumber < thirdNumber)
            {
                tempNumber = secondNumber;
                secondNumber = thirdNumber;
                thirdNumber = tempNumber;
            }
        }

        Console.WriteLine("The numbers in descending order are: {0}, {1}, {2}", firstNumber,
        secondNumber, thirdNumber);
    }
}