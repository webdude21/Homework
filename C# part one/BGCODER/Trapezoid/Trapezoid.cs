using System;

class Trapezoid
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == (n - j))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }

            for (int k = n; k < n*2; k++)
            {
                if (i == 0)
                {
                   Console.Write("*"); 
                }
                else if (k < n*2 - 1)
                {
                    Console.Write(".");
                }
                else if (k == n*2 -1 )
                {
                    Console.Write("*"); 
                }
            }
            Console.WriteLine();
        }
        for (int p = 0; p < n*2; p++)
        {
            Console.Write("*");
        }
    }
}