using System;

class BinaryDigitsCount
{
    static void Main()
    {
        int b = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        uint[,] number = new uint[n, 2];
        bool zeroes = false;

        for (int i = 0; i < n; i++)
        {
            number[i, 0] = uint.Parse(Console.ReadLine());
            for (int j = 0; j < 32; j++)
            {
                if (b == 0)
                {
                    if (((number[i, 0] << j) & 2147483648) == 2147483648)
                    {
                        zeroes = true; // strat counting only after you remove every 0 before the first 1.
                    }
                    if ((((~number[i, 0] << j) & 2147483648) == 2147483648) & (zeroes == true))
                    {
                        number[i, 1]++;
                    }
                }
                if (b == 1)
                {
                    if (((number[i, 0] >> j) & 1) == 1)
                    {
                        number[i, 1]++;
                    }
                }
            }
            zeroes = false;
        }
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine(number[i, 1]);
        }
    }
}