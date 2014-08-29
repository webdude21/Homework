namespace KaspichanNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;

    internal class KaspichanNumbers
    {
        private static void Main()
        {
            var input = BigInteger.Parse(Console.ReadLine());
            var digits = GenerateKaspichanDigits();
            var outputNumber = new List<string>(20);
            var kaspichanBase = 256;

            if (input == 0)
            {
                Console.WriteLine(digits[0]);
            }
            else
            {
                while (input > 0)
                {
                    outputNumber.Add(digits[(int)(input % kaspichanBase)]);
                    input = input / kaspichanBase;
                }

                PrintResult(outputNumber);
            }
        }

        private static void PrintResult(List<string> outputNumber)
        {
            outputNumber.Reverse();
            var result = string.Join(null, outputNumber);
            Console.WriteLine(result);
        }

        private static Dictionary<int, string> GenerateKaspichanDigits()
        {
            // This method generates the Kaspichanian digits
            var digits = new Dictionary<int, string>();
            var outputDigit = new StringBuilder(2);

            for (var i = 0; i < 256; i++)
            {
                if (i <= 25)
                {
                    digits.Add(i, ((char)(i + 65)).ToString());
                }
                else
                {
                    var tempNum = i % 26;
                    outputDigit.Append((char)(i / 26 + 96));
                    outputDigit.Append((char)(tempNum + 65));
                    digits.Add(i, outputDigit.ToString());
                    outputDigit.Clear();
                }
            }

            return digits;
        }
    }
}