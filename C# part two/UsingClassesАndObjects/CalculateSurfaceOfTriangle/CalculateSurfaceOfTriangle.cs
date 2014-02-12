//  Write methods that calculate the Area of a triangle by given:
// Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

using System;

class CalculateSurfaceOfTriangle
    {
        static void Main()
        {
            double a = 4;
            double b = 5;
            double c = 8;
            double h = 12.3;
            double angle = DegreesToRadians(60);

            AreaBySideAndHeight(a, h);
            AreaByThreeSides(a, b, c);
            AreaByTwoSidesAndAngleBetweenThem(a, b, angle);
        }

        static double DegreesToRadians(double angleInDegrees)
        {
            return (Math.PI / 180) * angleInDegrees;
        }

        static void AreaByThreeSides(double a, double b, double c)
        {
            // Heron's formula
            double perimeter = (a + b + c) / 2;
            double area = Math.Sqrt(perimeter * (perimeter - a) * (perimeter - b) * (perimeter - c));
            Console.WriteLine("Area of the triangle by given all its sides: {0:0.00}", area);
        }
        static void AreaBySideAndHeight(double side, double height)
        {
            double area = (side * height) / 2;
            Console.WriteLine("Area of the triangle by given side and attitude to it: {0:0.00}", area);
        }

        static void AreaByTwoSidesAndAngleBetweenThem(double a, double b, double angleInRadians)
        {
            double area = Convert.ToDouble((a * b * (Math.Sin(angleInRadians)) / 2));
            Console.WriteLine("Area of the triangle by given two sides and angle between them: {0:0.00}", area);
        }

    }
