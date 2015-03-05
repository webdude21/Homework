namespace VariableLengthCodes
{
    using System;
    using System.Linq;
    using System.Text;

    internal class Program
    {
        private static void Main()
        {
            var firstLineOfInput = Console.ReadLine();
            var encodedMessage = firstLineOfInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var encodedBitString = new StringBuilder();
            var recoveredMessage = new StringBuilder();

            foreach (var digit in encodedMessage.Select(int.Parse))
            {
                encodedBitString.Append(Convert.ToString(digit, 2).PadLeft(8, '0'));
            }

            var numbersOfLinesOfTheTable = int.Parse(Console.ReadLine());
            var lenghtCodesTable = new char[numbersOfLinesOfTheTable];

            for (var i = 0; i < numbersOfLinesOfTheTable; i++)
            {
                var input = Console.ReadLine();
                var charToSave = input[0];
                var index = int.Parse(input.Substring(1));
                lenghtCodesTable[index - 1] = charToSave;
            }

            var currentCodeLength = -1;

            for (var i = 0; i < encodedBitString.Length; i++)
            {
                if (encodedBitString[i] == '1')
                {
                    currentCodeLength++;
                }
                else
                {
                    if (currentCodeLength > -1)
                    {
                        recoveredMessage.Append(lenghtCodesTable[currentCodeLength]);
                    }

                    currentCodeLength = -1;
                }
            }

            Console.WriteLine(recoveredMessage);
        }
    }
}