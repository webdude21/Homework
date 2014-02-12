using System;
using System.Threading;
using System.Globalization;

class CircleRadiusPerimeter
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;                      
        double radius;
        Console.Write("Please input the radius 'r' of a circle: ");
        radius = double.Parse(Console.ReadLine());
        Console.WriteLine("The area of the circle is {0,00} \n\rThe perimeter of the circle is: {1,00}",
            Math.PI * radius * radius, 2 * radius * Math.PI);

    }
}
