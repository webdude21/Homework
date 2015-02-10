namespace SecretsOfNumbers
{
    using System;
    using System.Text;

    internal class SecretsOfNumbers
    {
        private static void Main()
        {
            var n = Console.ReadLine();
            var specialSum = 0;
            var odd = true;
            var position = 1;

            for (var i = n.Length - 1; i >= 0; i--)
            {
                var currentDigit = n[i] - '0';
                specialSum += odd ? currentDigit * (position * position) : (currentDigit * currentDigit) * position;
                odd = !odd;
                position++;
            }

            var specialSumAsString = specialSum.ToString();
            Console.WriteLine(specialSumAsString);
            var alphaSeqLenght = specialSumAsString[specialSumAsString.Length - 1] - '0';

            if (alphaSeqLenght == 0)
            {
                Console.WriteLine("{0} has no secret alpha-sequence", n);
            }
            else
            {
                var r = specialSum % 26;
                var alphaSeq = new StringBuilder();
                for (var i = 0; i < alphaSeqLenght; i++)
                {
                    var resultChar = (char)(r + i + 'A');
                    if (resultChar > 'Z')
                    {
                        resultChar = (char)(resultChar - 26);
                    }
                    alphaSeq.Append(resultChar);
                }
                Console.WriteLine(alphaSeq);
            }
        }
    }
}