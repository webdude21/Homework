using System;
    
class DecimalToBinary
{
    static void Main()
    {
        EasyWay();
        BitMoreDifficult();
    }

    static void BitMoreDifficult()
    {
        int num = GetInput();
        string output = "";

        while (num != 0)
        {
            output = (num % 2) + output;
            num = num / 2;
        }
        Console.Write("This is the result (the hard way): {0} \r\n", output);

    }

    static void EasyWay()
    {
        // This an built in function in C#, but I've decided it's way too easy :)
        int num = GetInput();
        Console.Write("This is the result (the easy way): ");
        Console.WriteLine(Convert.ToString(num, 2)); 
    }

    static int GetInput()
    {
        Console.Write("Enter number: ");
        int num = int.Parse(Console.ReadLine());
        return num;
    }
}
