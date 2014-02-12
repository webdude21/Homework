using System;

class OneToN
{
    static void Main(string[] args)
    {
        Console.Write("Please enter a number for 'n': ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}
