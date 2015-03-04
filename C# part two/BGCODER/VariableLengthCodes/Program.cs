namespace VariableLengthCodes
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            var encodedText = Console.ReadLine().Split().Select(int.Parse).ToList();
            var numbersOfLinesOfTheTable = int.Parse(Console.ReadLine());
        }
    }
}