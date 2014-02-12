using System;
class CartesianCoordinateSystem
{
    static void Main()
    {
        // The numbers X and Y are numbers between -2 000 000 000 001 337 and
        // 2 000 000 000 001 337, inclusive.
        Decimal X = Decimal.Parse(Console.ReadLine());
        Decimal Y = Decimal.Parse(Console.ReadLine());
        int result = 0;

        if (X == 0 && Y == 0)
        {
            result = 0;
        }
        else if (X != 0 && Y == 0)
        {
            result = 6;
        }
        else if (X == 0 && Y != 0)
        {
            result = 5;
        }
        else if (X > 0 && Y > 0)
        {
            result = 1;
        }
        else if (X < 0 && Y > 0)
        {
            result = 2;
        }
        else if (X < 0 && Y < 0)
        {
            result = 3;
        }
        else if (X > 0 && Y < 0)
        {
            result = 4;
        }
        Console.WriteLine(result);
    }
}