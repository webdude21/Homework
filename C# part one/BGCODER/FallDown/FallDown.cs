using System;

class FallDown
{
    static void Main()
    {
        int mask;
        int[] arrNumbers = new int[8];
        for (int i = 0; i < 8; i++)
        {
            arrNumbers[i] = int.Parse(Console.ReadLine());
        }
        for (int k = 0; k < 7; k++)
        {
            for (int i = 7; i > 0; i--)
            {
                for (int j = 0; j < 8; j++)
                {
                    mask = 0;
                    mask = 1 << j;
                    if ((mask & arrNumbers[i]) == 0)
                    {
                        if ((mask & arrNumbers[i - 1]) > 0)
                        {
                            arrNumbers[i - 1] &= ~mask;
                            arrNumbers[i] |= mask;
                        }
                    }
                }
            }
        }
        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine("{0}", arrNumbers[i]);
        }
    }
}