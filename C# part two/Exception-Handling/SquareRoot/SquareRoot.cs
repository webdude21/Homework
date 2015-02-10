// Write a program that reads an integer number and calculates and prints its square root. 
// If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". Use try-catch-finally.
namespace SquareRoot
{
    using System;

    internal class SquareRoot
    {
        private static void Main()
        {
            Console.Write("Enter a non negative number: ");
            try
            {
                var input = int.Parse(Console.ReadLine());
                CheckIfNegative(input);
                var squareRoot = Math.Sqrt(input);
                Console.WriteLine("The square root of {0} is {1}.", input, squareRoot);
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Invalid number!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number!");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }

        private static void CheckIfNegative(int number)
        {
            if (number < 0)
            {
                throw new ArithmeticException(
                    "Invalid number. The square root can only be used with non negative numbers!");
            }
        }
    }
}