namespace _9GagNumbers
{
    using System;
    using System.Collections.Generic;

    internal class _9GagNumbers
    {
        private static void Main()
        {
            var numbers = new Dictionary<string, ulong>
                              {
                                  { "-!", 0 }, 
                                  { "**", 1 }, 
                                  { "!!!", 2 }, 
                                  { "&&", 3 }, 
                                  { "&-", 4 }, 
                                  { "!-", 5 }, 
                                  { "*!!!", 6 }, 
                                  { "&*!", 7 }, 
                                  { "!!**!-", 8 }
                              };
            var input = Console.ReadLine();
            var digits = new Stack<ulong>();
            var startIndex = 0;

            for (var endIndex = 0; endIndex <= input.Length; endIndex++)
            {
                if (numbers.ContainsKey(input.Substring(startIndex, endIndex - startIndex)))
                {
                    digits.Push(numbers[input.Substring(startIndex, endIndex - startIndex)]);
                    startIndex = endIndex;
                }
            }

            ulong decimalResult = 0;
            ulong nBase = 9;
            ulong digit = 0;

            while (digits.Count > 0)
            {
                decimalResult = decimalResult + (digits.Pop() * Pow(nBase, digit));
                digit++;
            }

            Console.WriteLine(decimalResult);
        }

        private static ulong Pow(ulong nBase, ulong power)
        {
            if (power == 0)
            {
                return 1;
            }

            return nBase * Pow(nBase, power - 1);
        }
    }
}