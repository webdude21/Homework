using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter a number for 'n': ");
        int n = int.Parse(Console.ReadLine());
        int sum = 0;

        for (int i = 1; i <= n; i++)
        {
            Console.Write("Please enter the number for 'n+{0}': ", i);
            sum += int.Parse(Console.ReadLine());
        }
        Console.WriteLine("The sum of all the 'n' numbers is: {0}", sum);
    }
}
