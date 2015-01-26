namespace TribonacciTriangle
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            long firstT = int.Parse(Console.ReadLine());
            long secondT = int.Parse(Console.ReadLine());
            long thirdT = int.Parse(Console.ReadLine());
            long tribonacciLines = int.Parse(Console.ReadLine());
            var currentNumber = 0;
            var numbers = new List<long> { firstT, secondT, thirdT };

            for (var line = 2; line < tribonacciLines * tribonacciLines; line++)
            {
               numbers.Add(numbers[line - 2] + numbers[line - 1] + numbers[line]);
            }

            for (var i = 0; i < tribonacciLines; i++)
            {
                Console.WriteLine(string.Join(" ", numbers.GetRange(currentNumber += i, i + 1)));
            }
        }
    }
}