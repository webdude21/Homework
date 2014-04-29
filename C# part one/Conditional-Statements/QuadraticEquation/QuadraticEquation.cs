using System;
using System.Threading;
using System.Globalization;

class QuadraticEquation
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Write("Please enter a number for a: ");
        var a = double.Parse(Console.ReadLine());
        Console.Write("Please enter a number for b: ");
        var b = double.Parse(Console.ReadLine());
        Console.Write("Please enter a number for c: ");
        var c = double.Parse(Console.ReadLine());

        var D = ((b * b) - (4 * a * c));
        var onlyRoot = ((-b) / (2 * a));
        var firstRoot = ((-b) + (Math.Sqrt(D))) / (2 * a);
        var secondRoot = ((-b) - (Math.Sqrt(D))) / (2 * a);
        var oneRoot = (Math.Abs(D) < 0.0001);
        var twoRoots = (D > 0);
        // This is where solving the equation happens.

        if (oneRoot)
        {
            Console.WriteLine("The only real root of the equation is: {0:0.00}", onlyRoot);
        }
        else if (twoRoots)
        {
            Console.WriteLine("The two real root of the equation are: {0:0.00} and {1:0.00}", firstRoot,
                secondRoot);
        }
        else
        {
            Console.WriteLine("The equation has no roots");
        }
        // This is how the results of the equation (if any) are displayed.
    }
}
