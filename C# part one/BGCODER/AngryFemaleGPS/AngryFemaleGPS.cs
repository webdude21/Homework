namespace AngryFemaleGPS
{
    using System;
    using System.Linq;

    internal class AngryFemaleGps
    {
        private static void Main()
        {
            var input = Console.ReadLine();
            long oddSum = 0;
            long evenSum = 0;

            foreach (var digit in input.Where(char.IsDigit))
            {
                if (digit % 2 == 0)
                {
                    evenSum += digit - '0';
                }
                else
                {
                    oddSum += digit - '0';
                }
            }

            if (oddSum > evenSum)
            {
                Console.WriteLine("left {0}", oddSum);
            }
            else if (oddSum < evenSum)
            {
                Console.WriteLine("right {0}", evenSum);
            }
            else
            {
                Console.WriteLine("straight {0}", evenSum);
            }
        }
    }
}