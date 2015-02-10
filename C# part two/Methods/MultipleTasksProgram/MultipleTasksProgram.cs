// Write a program that can solve these tasks:
// Reverses the digits of a number
// Calculates the average of a sequence of integers
// Solves a linear equation a * x + b = 0
// Create appropriate methods.
//        Provide a simple text-based menu for the user to choose which task to solve.
//        Validate the input data:
// The decimal number should be non-negative
// The sequence should not be empty
// a should not be equal to 0
namespace MultipleTasksProgram
{
    using System;
    using System.Globalization;
    using System.Threading;

    internal class MultipleTasksProgram
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            ChooseTaskToSolve();
        }

        private static void ChooseTaskToSolve()
        {
            // Give the user a choose of operation on both polynomials
            Console.WriteLine("Please choose a task to solve: ");
            Console.WriteLine("(a) Reverses the digits of a number.");
            Console.WriteLine("(b) Calculates the average of a sequence of integers.");
            Console.WriteLine("(c) Solves a linear equation a * x + b = 0.");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "a":
                case "A":
                    SolveTaskReverseNumber();
                    break;
                case "b":
                case "B":
                    SolveTaskCalculateAvarage();
                    break;
                case "c":
                case "C":
                    SolveTaskLinearEquation();
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        private static void SolveTaskReverseNumber()
        {
            var validInput = false;
            while (!validInput)
            {
                Console.Write("Please input a number: ");
                decimal testNumber;
                var result = decimal.TryParse(Console.ReadLine(), out testNumber);

                if (!result || testNumber < 0)
                {
                    Console.WriteLine("The input was invalid!");
                }
                else
                {
                    Console.WriteLine("The number {0} is {1} when reversed.", testNumber, ReverseNumber(testNumber));
                    validInput = true;
                }
            }
        }

        private static decimal ReverseNumber(decimal number)
        {
            // I convert the number to array of chars. Then I reverse the array.
            // Then I convert the array of chars back to a number and return it to the caller.
            var numberAsChars = number.ToString().ToCharArray();
            Array.Reverse(numberAsChars);
            var reversedNumberAsString = new string(numberAsChars);
            return decimal.Parse(reversedNumberAsString);
        }

        private static void SolveTaskCalculateAvarage()
        {
            var input = 0;
            var validInput = false;

            while (!validInput || input <= 0)
            {
                Console.Write("Please the number of integers to expect: ");
                validInput = int.TryParse(Console.ReadLine(), out input);
            }

            CalculateAverage(input);
        }

        private static void CalculateAverage(int inputAmmount)
        {
            decimal sum = 0;
            decimal currentNumber = 0;

            for (var i = 1; i <= inputAmmount; i++)
            {
                Console.WriteLine("Please input integer <{0}>: ", i);
                var validInput = decimal.TryParse(Console.ReadLine(), out currentNumber);
                if (!validInput)
                {
                    i--;
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    sum = sum + currentNumber;
                }
            }

            Console.WriteLine("The average is {0:0.00}", sum / inputAmmount);
        }

        private static void SolveTaskLinearEquation()
        {
            decimal a = 0;
            decimal b = 0;
            var validInput = false;

            // Validate the input
            while (!validInput)
            {
                Console.Write("Please input a number for 'a' (should not be 0): ");
                validInput = decimal.TryParse(Console.ReadLine(), out a);
                validInput = validInput && a != 0;
                if (validInput)
                {
                    Console.Write("Please input a number for 'b': ");
                    validInput = validInput && decimal.TryParse(Console.ReadLine(), out b);
                }
            }

            SolveLinearEquation(a, b);
        }

        private static void SolveLinearEquation(decimal a, decimal b)
        {
            var x = -b / a;
            Console.WriteLine("X equals {0}", x);
        }
    }
}