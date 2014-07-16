/* Define abstract class Shape with only one abstract method CalculateSurface() and fields
 * width and height. Define two new classes Triangle and Rectangle that implement the virtual
 * method and return the surface of the figure (height*width for rectangle and height*width/2 
 * for triangle). Define class Circle and suitable constructor so that at initialization height 
 * must be kept equal to width and implement the CalculateSurface() method. Write a program that
 * tests the behavior of  the CalculateSurface() method for different shapes (Circle, Rectangle, 
 * Triangle) stored in an array. */
namespace Shapes
{
    using System;

    internal class ShapeTesting
    {
        private static void Main()
        {
            Shape[] shapes = { new Triangle(4, 8), new Circle(10), new Rectangle(4, 2) };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
            }
        }
    }
}