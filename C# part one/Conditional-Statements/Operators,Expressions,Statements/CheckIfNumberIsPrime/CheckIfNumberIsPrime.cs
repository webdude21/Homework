using System;

class Program
{
static void Main(string[] args)
{
    // Write an expression that checks if given positive integer number n 
    // (n ≤ 100) is prime. E.g. 37 is prime.

    byte input = 37;
    bool divisor = false;

    // If the number is prime it will it should only divide by one and itself.
    // In the loop I start with the number two and finish without
    // using the number itself as a divisor.

    for (byte n = 2; (n < input) && (divisor == false); n++)
    {
        divisor = (input % n) == 0 ? divisor = true : divisor = false;
    }

    if (divisor == false)
    {
        Console.WriteLine("The number is Prime");
    }
    else Console.WriteLine("The number is Composite");

    Console.WriteLine("Press any key to close the application!");
    Console.ReadLine();

}
}

