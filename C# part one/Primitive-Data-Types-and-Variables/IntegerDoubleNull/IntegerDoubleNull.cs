using System;

class IntegerDoubleNull
{
    static void Main(string[] args)
    {
        int? blankInt = null;
        double? blankDouble = null;

        Console.WriteLine(blankInt);
        Console.WriteLine(blankDouble);

        blankInt =+ 10;
        blankDouble =+ 20;

        Console.WriteLine(blankInt);
        Console.WriteLine(blankDouble);

        blankInt = blankInt + null;
        blankDouble = blankDouble + null;

        Console.WriteLine(blankInt);
        Console.WriteLine(blankDouble);
    }
}
