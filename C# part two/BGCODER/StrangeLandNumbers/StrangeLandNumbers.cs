namespace StrangeLandNumbers
{
    using System;

    internal class StrangeLandNumbers
    {
        private static void Main()
        {
            var numbers = new[] { "f", "bIN", "oBJEC", "mNTRAVL", "lPVKNQ", "pNWE", "hT" };
            var result = Console.ReadLine();
            long output = 0;

            for (var i = 0; i < numbers.Length; i++)
            {
                result = result.Replace(numbers[i], i.ToString());
            }

            var power = 0;

            for (var i = result.Length - 1; i >= 0; i--)
            {
                output += (long)((result[i] - '0') * Math.Pow(7d, power));
                power += 1;
            }

            Console.WriteLine(output);
        }
    }
}