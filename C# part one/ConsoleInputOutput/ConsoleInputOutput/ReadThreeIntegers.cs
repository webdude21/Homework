using System;

class ReadThreeIntegers
{
    static void Main(string[] args)
    {
        int a, b, c;
        Console.Write("Please input the first integer: ");
        a = int.Parse(Console.ReadLine());
        Console.Write("Please input the second integer: ");
        b = int.Parse(Console.ReadLine());
        Console.Write("Please input the third integer: ");
        c = int.Parse(Console.ReadLine());

        Console.WriteLine("The sum of the three integers is: {0}", a + b + c);
    }
}
