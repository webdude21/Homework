using System;
using System.IO;
using System.Text;

class GenomeDecoder
{
    static void Main()
    {   
        string[] nAndM = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int n = int.Parse(nAndM[0]);
        int m = int.Parse(nAndM[1]);
        int currentN = 0;
        int currentM = 0;
        int currentLine = 1;
        StringBuilder decodedInput = Decode(Console.ReadLine());
        StringBuilder result = new StringBuilder(decodedInput.Length);
        string indent = CalculateIndent(n, decodedInput.Length);

        result.Append(string.Format(indent, currentLine));
        for (int ch = 0; ch < decodedInput.Length; ch++)
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

    static string CalculateIndent(int n, int decodedInput)
    {
        int numberOfLines = (decodedInput / n);
        if (decodedInput % n != 0)
        {
            numberOfLines++;
        }
        return "{0," + numberOfLines.ToString().Length + "} ";
    }
    static StringBuilder Decode(string input)
    {
        StringBuilder result = new StringBuilder();
        int currNum = 0;

        for (int ch = 0; ch < input.Length; ch++)
        {
            if (Char.IsDigit(input[ch]))
            {
                currNum = (input[ch] - '0') + (currNum * 10);
            }
            else
            {
                char currChar = input[ch];
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