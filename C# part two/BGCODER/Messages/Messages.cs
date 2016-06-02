namespace Messages
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;

    internal class Messages
    {
        private const int CodeLength = 3;

        private static readonly string[] EncodeSystem =
            {
                "cad", "xoz", "nop", "cyk", "min", "mar", "kon", "iva", "ogi", "yan"
            };

        private static readonly Dictionary<string, int> DecodeSystem = new Dictionary<string, int>
                                                                           {
                                                                               { "cad", 0 },
                                                                               { "xoz", 1 },
                                                                               { "nop", 2 },
                                                                               { "cyk", 3 },
                                                                               { "min", 4 },
                                                                               { "mar", 5 },
                                                                               { "kon", 6 },
                                                                               { "iva", 7 },
                                                                               { "ogi", 8 },
                                                                               { "yan", 9 }
                                                                           };

        private static void Main()
        {
            var firstArgument = DecodeNumber(Console.ReadLine());
            var operation = Console.ReadLine();
            var secondArgumernt = DecodeNumber(Console.ReadLine());
            var result = EncodeNumber(operation == "-" ? firstArgument - secondArgumernt : firstArgument + secondArgumernt);
            Console.WriteLine(result);
        }

        private static string EncodeNumber(BigInteger numberToEncode)
        {
            var sb = new StringBuilder();
            var numberAsString = numberToEncode.ToString();

            foreach (var chr in numberAsString)
            {
                sb.Append(EncodeSystem[chr - '0']);
            }

            return sb.ToString();
        }

        private static BigInteger DecodeNumber(string encodedNumber)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < encodedNumber.Length; i+=3)
            {
                sb.Append(DecodeSystem[encodedNumber.Substring(i, CodeLength)]);
            }

            return BigInteger.Parse(sb.ToString());
        }
    }
}