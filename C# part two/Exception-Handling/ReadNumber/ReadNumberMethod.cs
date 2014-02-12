// Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end].
// If an invalid number or non-number text is entered, the method should throw an exception. 
// Using this method write a program that enters 10 numbers:


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReadNumberMethod
{
    static int ReadNumber(int start, int end)
    {
        int n = int.Parse(Console.ReadLine());

        if (start > n || n > end)
        {
            throw new ArgumentOutOfRangeException();
        }

        return n;
    }

    static void Main()
    {
        int min = 1, max = 100;
        int enteredNumber = 0;
        Console.WriteLine("Please input 10 numbers from 1 to 100: ");
        for (int i = 0; i < 10; i++)
        {
            try
            {
                Console.Write("Please write a number <{0}> between 1 and 100: ", i+1);
                enteredNumber = ReadNumber(min, max); 
            }
            catch (ArgumentOutOfRangeException)
            {
                i--;
                Console.WriteLine("The number was out of the acceptable range.");
            }
            catch (FormatException)
            {
                i--;
                Console.WriteLine("The number wasn't in the correct format.");
            }

        }
    }
}