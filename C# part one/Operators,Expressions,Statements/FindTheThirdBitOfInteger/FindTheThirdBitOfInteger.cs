using System;

class Program
{
static void Main(string[] args)
{

    //Write a boolean expression for finding if the bit 3 (counting from 0) 
    //of a given integer is 1 or 0.

    int number = 22;

    if ((number & 8) != 0)  // another way is to do is ((number & 8) == 8)
        Console.WriteLine("The third bit of {0} is 1", number);
    else Console.WriteLine("The third bit of {0} is 0", number);

    Console.WriteLine("Press any key to close the application!");
    Console.ReadLine();
}
}
