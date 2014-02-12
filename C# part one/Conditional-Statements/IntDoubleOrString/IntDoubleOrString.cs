using System;
using System.Threading;
using System.Globalization;

class IntDoubleOrString
{
    static void Main()
    {
		// Write a program that, depending on the user's choice inputs int, 
		// double or string variable. If the variable is integer or double, 
		// increases it with 1. If the variable is string, appends "*" at its end. 
		// The program must show the value of that variable as a console output. 
		// Use switch statement.
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; 
		
		double userDouble = 0d;
		int userInt = 0;
		string userInput = "";
		
		// Try to parse as integer first, if it's not possible then try to parse as double.
		// If it's neither an integer nor a double then it's treated as a string.
        Console.Write("Please enter an integer, double or string: ");
		userInput = Console.ReadLine();
		if (int.TryParse(userInput, out userInt))
		{
		userInput = "Integer";
		}
		else if (double.TryParse(userInput, out userDouble))
				{
				userInput = "Double";
				}

		// I could've made the program without the switch statement, but it's required.
		switch (userInput)
        {	
		    case "Integer":
                Console.WriteLine("The result is: {0}", ++userInt);
				break;
			case "Double":
                Console.WriteLine("The result is: {0}", ++userDouble);
				break;
			default:
                Console.WriteLine("The result is: {0}*", userInput);
				break;
        }
    }
}
