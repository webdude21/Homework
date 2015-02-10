//  Write methods that calculate the Area of a triangle by given:
// Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

using System;

internal class CalculateSurfaceOfTriangle
{
    private static void Main()
    {
        double a = 4;
        double b = 5;
        double c = 8;
        var h = 12.3;
        var angle = DegreesToRadians(60);

        AreaBySideAndHeight(a, h);
        AreaByThreeSides(a, b, c);
        AreaByTwoSidesAndAngleBetweenThem(a, b, angle);
    }

    private static double DegreesToRadians(double angleInDegrees)
    {
        return (Math.PI / 180) * angleInDegrees;
    }

    private static void AreaByThreeSides(double a, double b, double c)
    {
        // Heron's formula
        var perimeter = (a + b + c) / 2;
        var area = Math.Sqrt(perimeter * (perimeter - a) * (perimeter - b) * (perimeter - c));
        Console.WriteLine("Area of the triangle by given all its sides: {0:0.00}", area);
    }

    private static void AreaBySideAndHeight(double side, double height)
    {
        var area = (side * height) / 2;
        Console.WriteLine("Area of the triangle by given side and attitude to it: {0:0.00}", area);
    }

    private static void AreaByTwoSidesAndAngleBetweenThem(double a, double b, double angleInRadians)
    {
        var area = Convert.ToDouble(a * b * (Math.Sin(angleInRadians)) / 2);
        Console.WriteLine("Area of the triangle by given two sides and angle between them: {0:0.00}", area);
    }
}