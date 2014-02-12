using System;

class SingOfProduct
{
    static void Main()
    {
        // Write a program that shows the sign (+ or -) of the product of three 
        // real numbers without calculating it. Use a sequence of if statements.

        double[] numbers = new double[3];
        bool[] isNegative = new bool[3];

        // I've decided to use arrays for the variables since it's a bit faster.

        Console.WriteLine("Please enter three numbers (on separate lines).");

        for (byte i = 0; i < 3; i++)
        {
            // I've used a loop to gather the numbers and check if they're positive or not
            numbers[i] = Double.Parse(Console.ReadLine());
            if (numbers[i] > 0)
            {
                isNegative[i] = false;
            }
            else if (numbers[i] < 0)
            {
                isNegative[i] = true;
            }
        }

        // Check if any of the numbers is zero, if so then the product is zero.
        if (numbers[0] == 0 || numbers[1] == 0 || numbers[2] == 0)
        {
            Console.WriteLine("The product of the numbers is zero");
        }
        else if ((isNegative[0] ^ isNegative[1] ^ isNegative[2]) == true)
        {
            Console.WriteLine("The product of the numbers is negative");
        }
        else
        {
            Console.WriteLine("The product of the numbers is positive");
        }
    }
}
