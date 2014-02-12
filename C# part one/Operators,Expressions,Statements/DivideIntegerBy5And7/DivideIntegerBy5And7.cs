using System;

class Program
{
static void Main(string[] args)
{
    int dividend;
    Console.Write("Enter a number to check if can be divided by both 5 and 7 without remainder: ");
    dividend = Convert.ToInt32(Console.ReadLine());
    if ((dividend % (5*7)) == 0)
    // In order for a number to be divided by 5 and 7 without remainder,
    // it's necessary to check if the number can be divided without remainder by product of 5 and 7 which is 35! 
        Console.WriteLine("It can be divided without remainder!");
    else Console.WriteLine("It cannot be divided without remainder!");
    Console.WriteLine("Press any key to close the application!");
    Console.ReadLine();
}
}