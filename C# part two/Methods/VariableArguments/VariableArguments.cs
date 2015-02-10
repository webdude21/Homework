// Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments.
namespace VariableArguments
{
    using System;

    internal class VariableArguments
    {
        private static void Main()
        {
            Demo();
        }

        private static void Demo()
        {
            Console.WriteLine("The smallest number of 1, 4, 5, -8, 10 is {0}", MinimumNumber(1, 4, 5, -8, 10));
            Console.WriteLine("The biggest number of 1, 4, 5, -8, 10 is {0}", MaximumNumber(1, 4, 5, -8, 10));
            Console.WriteLine("The sum of 1, 4, 5, -8, 10 is {0}", SumNumbers(1, 4, 5, -8, 10));
            Console.WriteLine("The average of 1, 4, 5, -8, 10 is {0}", AverageNumbers(1, 4, 5, -8, 10));
            Console.WriteLine("The product of 1, 4, 5, -8, 10 is {0}", MultiplyNumbers(1, 4, 5, -8, 10));
        }

        private static decimal MinimumNumber(params decimal[] input)
        {
            Array.Sort(input);
            return input[0];
        }

        private static decimal MaximumNumber(params decimal[] input)
        {
            Array.Sort(input);
            return input[input.Length - 1];
        }

        private static decimal SumNumbers(params decimal[] input)
        {
            decimal sum = 0;
            for (var i = 0; i < input.Length; i++)
            {
                sum = sum + input[i];
            }

            return sum;
        }

        private static decimal MultiplyNumbers(params decimal[] input)
        {
            decimal product = 1;
            for (var i = 0; i < input.Length; i++)
            {
                product = product * input[i];
            }

            return product;
        }

        private static decimal AverageNumbers(params decimal[] input)
        {
            return SumNumbers(input) / input.Length;
        }
    }
}