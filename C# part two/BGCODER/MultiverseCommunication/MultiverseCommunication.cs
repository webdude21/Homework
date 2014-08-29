namespace MultiverseCommunication
{
    using System;
    using System.Collections.Generic;

    internal class MultiverseCommunication
    {
        private static void Main()
        {
            var input = Console.ReadLine();
            var codes = new Dictionary<string, double>
                            {
                                { "CHU", 0 }, 
                                { "TEL", 1 }, 
                                { "OFT", 2 }, 
                                { "IVA", 3 }, 
                                { "EMY", 4 }, 
                                { "VNB", 5 }, 
                                { "POQ", 6 }, 
                                { "ERI", 7 }, 
                                { "CAD", 8 }, 
                                { "K-A", 9 }, 
                                { "IIA", 10 }, 
                                { "YLO", 11 }, 
                                { "PLA", 12 }, 
                            };

            var wordLenght = 3;
            var nBase = 13;
            double digit = (input.Length / wordLenght) - 1;
            double decimalResult = 0;

            for (var i = 0; i < input.Length; i += wordLenght)
            {
                var currentdigit = input.Substring(i, wordLenght);
                if (codes.ContainsKey(currentdigit))
                {
                    decimalResult = decimalResult + (codes[currentdigit] * Math.Pow(nBase, digit));
                }

                digit--;
            }

            Console.WriteLine(decimalResult);
        }
    }
}