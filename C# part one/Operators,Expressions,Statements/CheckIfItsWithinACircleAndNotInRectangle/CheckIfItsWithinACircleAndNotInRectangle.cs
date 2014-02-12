using System;

class CheckIfItsWithinACircleAndNotInRectangle
{
static void Main(string[] args)
{
    //Write an expression that checks for given point (x, y) if it is within
    //the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).

    float x = 1.5F;
    float y = 0.5F;

    bool withinCircle = false;
    bool withinRectangle = false;

    if ((((x - 1) * (x - 1)) + ((y - 1) * (y - 1)) <= 9) ? withinCircle = true : withinCircle = false)
    // Checks if the point with coordinats (x,y) is within the circle
    if ((((-1 <= x) && (x <= 5)) && ((-1 <= y) && (y <= 1))) ? withinRectangle = true : withinRectangle = false)
    Console.Write("The point is ");
    Console.Write(withinCircle ? "within the circle and " : "outside the circle and ");
    Console.WriteLine(withinRectangle ? "within the within Rectangle" : "outside the Rectangle");
    Console.WriteLine("Press any key to close the application!");
    Console.ReadLine();

}
}
