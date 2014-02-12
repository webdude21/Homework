using System;

class Program
{
    static void Main(string[] args)
    {
        int currentAge;
        Console.Write("Please enter your current age: ");
        currentAge = Int32.Parse(Console.ReadLine()); 
        // Here we can also add an error handling, but it's too early for this
        Console.WriteLine("Your age in 10 years will be: {0}", currentAge + 10);
        Console.WriteLine("Press any key to close the application!");
        Console.ReadLine();
    }
}

