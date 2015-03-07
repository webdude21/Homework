namespace SumofDifferences
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    internal class Program
    {
        private static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var inputInts = new List<long>();

            for (var i = 0; i < input.Length; i++)
            {
                inputInts.Add(long.Parse(input[i]));
            }

            var index = 1;
            BigInteger sum = 0;

            while (index < inputInts.Count)
            {
                var a = inputInts[index - 1];
                var b = inputInts[index];
                var absoluteDifference = GetAbsoluteDifference(a, b);
                var isEven = CheckIfEven(absoluteDifference);

                if (!isEven)
                {
                    index += 1;
                    sum += absoluteDifference;
                }
                else
                {
                    index += 2;
                }
            }

            Console.WriteLine(sum);
        }

        private static bool CheckIfEven(long absoluteDifference)
        {
            return absoluteDifference % 2 == 0;
        }

        private static long GetAbsoluteDifference(long a, long b)
        {
            if (a > b)
            {
                return Math.Abs(a - b);
            }
            return  Math.Abs(b - a);
        }
    }
}