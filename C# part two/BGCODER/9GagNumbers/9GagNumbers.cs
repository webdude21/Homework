using System;
using System.Collections.Generic;
using System.Text;

class _9GagNumbers
{
    static void Main()
    {
        Dictionary<string, ulong> numbers = new Dictionary<string, ulong>() { 
        { "-!", 0 }, { "**", 1 }, { "!!!", 2 }, { "&&", 3 }, { "&-", 4 }, { "!-", 5 }, { "*!!!", 6 }, { "&*!", 7 }, { "!!**!-", 8 } };
        string input = Console.ReadLine();
        Stack<ulong> digits = new Stack<ulong>();
        int startIndex = 0;

        for (int endIndex = 0; endIndex <= input.Length; endIndex++)
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
            decimalResult = decimalResult + (digits.Pop() * (Pow(nBase, digit)));
            digit++;
        }

        Console.WriteLine(decimalResult);
    }
    static ulong Pow(ulong nBase, ulong power)
    {
        if (power == 0)
        {
            return (ulong)1;
        }

        return nBase * Pow(nBase, power - 1);
    }
}