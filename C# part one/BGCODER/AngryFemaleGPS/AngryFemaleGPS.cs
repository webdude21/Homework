using System;
class AngryFemaleGPS
{
    static void Main()
    {
        var input = Console.ReadLine();
        long oddSum = 0;
        long evenSum = 0;

        foreach (var chr in input)
        {
            if (char.IsDigit(chr))
            {
                if (chr % 2 == 0)
                {
                    evenSum += (chr - '0');
                }
                else
                {
                    oddSum += (chr - '0');
                }
            }
        }

        if (oddSum > evenSum) Console.WriteLine("left {0}", oddSum);
        else if (oddSum < evenSum) Console.WriteLine("right {0}", evenSum);
        else Console.WriteLine("straight {0}", evenSum);
    }
}

