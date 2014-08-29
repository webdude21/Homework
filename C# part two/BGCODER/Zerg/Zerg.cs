namespace Zerg
{
    using System;
    using System.Collections.Generic;

    internal class Zerg
    {
        private static void Main()
        {
            var input = Console.ReadLine();
            var codes = new Dictionary<string, double>
                            {
                                { "Rawr", 0 }, 
                                { "Rrrr", 1 }, 
                                { "Hsst", 2 }, 
                                { "Ssst", 3 }, 
                                { "Grrr", 4 }, 
                                { "Rarr", 5 }, 
                                { "Mrrr", 6 }, 
                                { "Psst", 7 }, 
                                { "Uaah", 8 }, 
                                { "Uaha", 9 }, 
                                { "Zzzz", 10 }, 
                                { "Bauu", 11 }, 
                                { "Djav", 12 }, 
                                { "Myau", 13 }, 
                                { "Gruh", 14 }, 
                            };

            var wordLenght = 4;
            double digit = (input.Length / wordLenght) - 1;
            double decimalResult = 0;
            var nBase = 15;

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