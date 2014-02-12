using System;

class SortNumbers
{
    static void Main()
    {
		// Sort 3 real values in descending order using 
		// nested if statements.

		decimal firstNumber, secondNumber, thirdNumber, tempNumber;
		
		Console.WriteLine("Please enter three numbers (on separate lines).");
		firstNumber = decimal.Parse(Console.ReadLine());
        secondNumber = decimal.Parse(Console.ReadLine());
        thirdNumber = decimal.Parse(Console.ReadLine());

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

/// 1, 2, 3
/// 1, 3, 2
/// 3. 1. 2