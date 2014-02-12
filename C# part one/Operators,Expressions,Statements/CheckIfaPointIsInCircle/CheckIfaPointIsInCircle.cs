using System;

class Program
{
    static void Main(string[] args)
    {
        // Write an expression that checks if given point (x,  y) 
        // is within a circle K(O, 5).
        // The radius of the circle is 5 so X^2 + Y^2 = R^2

        // I used http://www.mathopenref.com/coordbasiccircle.html

        int x = 3;
        int y = 3;

        if (((x*x) + (y*y)) < (5*5)) 
        {
            Console.WriteLine("The point is whitin the cirle");    
        }
        else Console.WriteLine("The point is outside of the cirle");

        Console.WriteLine("Press any key to close the application!");
        Console.ReadLine();


    }
}

