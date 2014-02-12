using System;

class KaspichaniaBoats
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int width = (n * 2) + 1;
        int height = 6 + ((n - 3) / 2) * 3;
        int basewidth = ((n - 3) / 2);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (j == n)
                {
                    Console.Write("*");
                }
                else if (n - i == j)
                {
                    Console.Write("*");
                }
                else if (n + i == j)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }

        for (int i = 0; i < width; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine();

        for (int i = 0; i < height - n - 2; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (j == n)
                {
                    Console.Write("*");
                }
                else if (i + 1 == j)
                {
                    Console.Write("*");
                }
                else if (width - i - 2 == j)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }

        for (int i = 0; i < width; i++)
        {
            if (i - 1 > basewidth && i + 2 < width - basewidth)
            {
                Console.Write("*");
            }
            else
            {
                Console.Write(".");
            }
        }
        Console.WriteLine();
    }
}