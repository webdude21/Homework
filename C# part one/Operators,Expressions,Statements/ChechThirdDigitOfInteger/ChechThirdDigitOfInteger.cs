using System;

class ChechThirdDigitOfInteger
{
    static void Main(string[] args)
    {
        int number = 1743;  
        Console.WriteLine("The third digit of {0} reading left to right is 7: {1}",
            number, (((number % 1000)/100) == 7));
        Console.WriteLine("Press any key to close the application!");
        Console.ReadLine();
    }
}
