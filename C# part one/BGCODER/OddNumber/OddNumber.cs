using System;
 
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long number = long.Parse(Console.ReadLine());
        for (int i = 0; i < n - 1; i++)
        {
            number = number ^ long.Parse(Console.ReadLine());
        }
        Console.WriteLine(number);
    }
}