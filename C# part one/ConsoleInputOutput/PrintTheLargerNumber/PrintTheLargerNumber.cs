using System;

class PrintTheLargerNumber
{
    static void Main(string[] args)
    {
        int a;
        int b;
        

        Console.Write("Please enter the first integer: ");
        a = int.Parse(Console.ReadLine());
        Console.Write("Please enter the second integer: ");
        b = int.Parse(Console.ReadLine());

        Console.WriteLine("The larger number is: {0}",Math.Max(a,b));

        // You can also use case switch like so ...
        //
        // bool largerInt = (a>b);  
        // switch (largerInt) 
        // {
        //     case true:
        //         Console.WriteLine("The larger number is: {0}", a);
        //         break;
        //     case false:     
        //         Console.WriteLine("The larger number is: {0}", b);
        //         break;
        // }
        // 
        // I could've also used the shorthand if (the ternary operator ?:), but it's still an if
        // statement.
    }
}
