using System;

class SumPrecision
{
    static void Main(string[] args)
    {

        double n = 2;
        double oldSum = 0;
        double newSum = 1;
        bool positive = true;

        while (Math.Abs((newSum - oldSum)) > 0.001 )
        {
            oldSum = newSum;
            if (positive == true)
            {
                newSum = newSum + (1 / n);
            } 
            else newSum = newSum - (1 / n);
            positive = !positive;
            n++;
        }

        Console.WriteLine("The sum of the numbers is: {0}", oldSum);

    }
}
