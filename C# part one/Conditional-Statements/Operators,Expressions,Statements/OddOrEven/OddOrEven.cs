using System;

class Program
{
static void Main(string[] args)
{
    int oddOrEven;
    Console.Write("Please enter a number to check if it's odd or even!: ");
    oddOrEven = Convert.ToInt32(Console.ReadLine());
    if ((oddOrEven & 1) == 0)
        // if (oddOrEven % 2 == 0) can also be used to check if the integer can be 
        // devided by 2 without remainder thus checking if the number is odd or Even
        Console.WriteLine("The number you've entered is Even!");
    else Console.WriteLine("The number you've entered is Odd!");
    Console.WriteLine("Press any key to close the application!");
    Console.ReadLine();
}
}