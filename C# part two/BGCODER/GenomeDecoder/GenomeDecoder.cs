namespace GenomeDecoder
{
    using System;
    using System.Text;

    internal class GenomeDecoder
    {
        private static void Main()
        {
            var nAndM = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(nAndM[0]);
            var m = int.Parse(nAndM[1]);
            var currentN = 0;
            var currentM = 0;
            var currentLine = 1;
            var decodedInput = Decode(Console.ReadLine());
            var result = new StringBuilder(decodedInput.Length);
            var indent = CalculateIndent(n, decodedInput.Length);

            result.Append(string.Format(indent, currentLine));
            for (var ch = 0; ch < decodedInput.Length; ch++)
            {
                currentM++;
                currentN++;
                result.Append(decodedInput[ch]);
                if (currentN == n && ch != decodedInput.Length - 1)
                {
                    currentLine++;
                    result.AppendLine();
                    result.Append(string.Format(indent, currentLine));
                    currentN = 0;
                    currentM = 0;
                }

                if (currentM == m && ch != decodedInput.Length - 1)
                {
                    result.Append(' ');
                    currentM = 0;
                }
            }

            Console.WriteLine(result);
        }

        private static string CalculateIndent(int n, int decodedInput)
        {
            var numberOfLines = decodedInput / n;
            if (decodedInput % n != 0)
            {
                numberOfLines++;
            }

            return "{0," + numberOfLines.ToString().Length + "} ";
        }

        private static StringBuilder Decode(string input)
        {
            var result = new StringBuilder();
            var currNum = 0;

            for (var ch = 0; ch < input.Length; ch++)
            {
                if (char.IsDigit(input[ch]))
                {
                    currNum = (input[ch] - '0') + (currNum * 10);
                }
                else
                {
                    var currChar = input[ch];
                    if (currNum > 0)
                    {
                        result.Append(currChar, currNum);
                        currNum = 0;
                    }
                    else
                    {
                        result.Append(currChar);
                    }
                }
            }

            return result;
        }
    }
}