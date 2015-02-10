namespace ShortToBite
{
    using System;

    internal class ShortToBynary
    {
        private static void Main()
        {
            ShortToByteTheEaseyWay();
            ShortToByteTheOtherWay();
        }

        private static void ShortToByteTheEaseyWay()
        {
            // This is again the trivial built in way
            Console.Write("Please enter a signed short integer: ");
            Console.Write(
                "The binary representation of the number is: {0}", 
                Convert.ToString(short.Parse(Console.ReadLine()), 2));
            Console.WriteLine();
        }

        private static void ShortToByteTheOtherWay()
        {
            Console.Write("Please enter a signed short integer: ");
            var input = short.Parse(Console.ReadLine());
            var output = string.Empty;

            // Bit shifting way
            // The current string is concatenated to current bit and the current string 
            // (putting each and every digit on the left side of the already existring one)
            // Could have done it with string builder
            for (var i = 0; i < 16; i++)
            {
                output = ((input >> i) & 1) + output;
            }

            Console.Write("The binary representation of the number is: {0}", output);
            Console.WriteLine();
        }
    }
}