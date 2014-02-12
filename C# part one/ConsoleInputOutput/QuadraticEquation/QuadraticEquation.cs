using System;
using System.Threading;
using System.Globalization;

class QuadraticEquation
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;   
        Console.Write("Please enter a number for a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Please enter a number for b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Please enter a number for c: ");
        double c = double.Parse(Console.ReadLine());

        double D = ((b * b) - (4 * a * c));
        double onlyRoot = ((-b) / (2 * a));
        double firstRoot = ((-b) + (Math.Sqrt(D))) / (2 * a);
        double secondRoot = ((-b) - (Math.Sqrt(D))) / (2 * a);
        bool oneRoot = (D == 0);
        bool twoRoots = (D > 0);
        
        if (oneRoot == true)
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
    }
}
